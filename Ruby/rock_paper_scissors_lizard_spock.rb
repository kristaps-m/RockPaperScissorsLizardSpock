require 'colorize'
require_relative 'constants'
require_relative 'print_tools'
require_relative 'score_tools'

class RockPaperScissorsLizardSpock
  def initialize
    @player_score = 0
    @computer_score = 0
    @choices = CHOICES
    @rounds = 0
    @computer_names = GAME_PARTICIPANTS_NAMES
    @print_tools = PrintTools.new()
    @score_tools = ScoreTools.new()
    @round_against_computer = ROUND_AGAINST_COMPUTER
  end

  def get_player_choice_from_input(round_number)
    valid_choice = false
    while !valid_choice
      print "It's round #{round_number}. Enter your (#{@choices.join('/')}) choice : "
      player_choice = gets.chomp.downcase
      if @choices.include? player_choice
        valid_choice = true
      else
        puts "Invalid choice. Please try again.".red
      end
    end

    return player_choice
  end

  def get_valid_player_input(text_player_can_see, min_number, max_number)
    valid_input = false
    while !valid_input
      print text_player_can_see + " (#{min_number}-#{max_number})\n  :"
      player_input = gets.chomp
      # /\A\d+\z/.match?(player_input) = is Integer?
      if /\A\d+\z/.match?(player_input) && min_number <= player_input.to_i && player_input.to_i <= max_number
        valid_input = true
      else
        puts "Invalid input. Please enter number from #{min_number} to #{max_number}.".red
      end
    end

    return player_input.to_i
  end

  def get_computer_choice
    CHOICES.sample
  end

  def determine_winner(player_choice, computer_choice)
    if player_choice == computer_choice
      return "It's a tie!"
    elsif GAME_OUTCOMES[player_choice].include? computer_choice
      @player_score += 1
      return "You win this round!".green
    else
      @computer_score += 1
      return "Computer wins this round!".red
    end
  end

  def is_rounds_equal_to_zero?(is_human_playing, result, number_of_rounds_with_each_opponent, player_name, computer_name)
    if !(result.include? "It's a tie!")
      @rounds -= 1
      if is_human_playing
        @round_against_computer += 1
      end
    end
    if @rounds == 0
      one_round_results = @print_tools.show_one_round_results(@player_score, @computer_score,number_of_rounds_with_each_opponent)
      @score_tools.update_scores(player_name, @player_score, computer_name, @computer_score)
      if is_human_playing
        puts one_round_results
        @round_against_computer = ROUND_AGAINST_COMPUTER
      end
      @player_score = 0
      @computer_score = 0
      @rounds = number_of_rounds_with_each_opponent

      return true
    end

    return false
  end

  def play_game
    @print_tools.print_beginning_of_game(@choices, @computer_names)
    player_name = PLAYER_NAME
    number_of_opponents = get_valid_player_input("Enter number of computer players!",
                                                      MIN_ROUNDS_AND_OPPONENTS, MAX_OPPONENTS)
    number_of_rounds_with_each_opponent = get_valid_player_input(
        "Enter number of rounds with each opponent!", MIN_ROUNDS_AND_OPPONENTS, MAX_ROUNDS)
    @rounds = number_of_rounds_with_each_opponent
    @score_tools.create_scores_list(number_of_opponents)

    for game_nr in 1..number_of_opponents
      puts "\n\n"
      puts "This is game #{game_nr} against #{@computer_names[game_nr]}"
      while true
        computer_choice = get_computer_choice
        # puts "----->>>>> " + computer_choice  # print computer choice for testing
        player_choice = get_player_choice_from_input(@round_against_computer)
        # player_choice = @score_tools.automatically_pick_winning_move_against_computer(computer_choice)
        puts "You chose: #{player_choice}"
        puts "Computer #{@computer_names[game_nr]} chose: #{computer_choice}"
        result = determine_winner(player_choice, computer_choice)
        puts result

        if is_rounds_equal_to_zero?(true, result, number_of_rounds_with_each_opponent, player_name, @computer_names[game_nr])
          break
        end
      end
    end

    # ---- remaining computers play against each other ----
    for computer_game_index in 1..number_of_opponents
      computer_main_player_name = @computer_names[computer_game_index]
      #for computer_opponent_index in range(1 + computer_game_index, number_of_opponents + 1):
      for computer_opponent_index in 1 + computer_game_index..number_of_opponents
        cpu_played_against_name = @computer_names[computer_opponent_index]
        while true
          computer_main_player_choice = get_computer_choice()
          cpu_played_against_choice = get_computer_choice()
          result = determine_winner(computer_main_player_choice, cpu_played_against_choice)

          if is_rounds_equal_to_zero?(false, result, number_of_rounds_with_each_opponent, computer_main_player_name, cpu_played_against_name)
            break
          end
        end
      end
    end

    @print_tools.print_scores(@score_tools.scores)
    @score_tools.count_games_won_for_each_player(number_of_opponents)
    puts "-------"
    @score_tools.sort_and_print_player_names_and_games_won

    if @score_tools.have_you_won_the_game_with_most_wins?
      puts "\nYou won all #{number_of_opponents} computer opponents!\nCongratulations!"
    else
      puts "\nYou lost against computer!"
    end
  end
end
