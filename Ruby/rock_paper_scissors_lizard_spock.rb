require 'colorize'
require_relative 'constants'
require_relative 'print_tools'
require_relative 'score_tools'

class RockPaperScissorsLizardSpock
  def initialize
    # @player_score = 0
    # @computer_score = 0
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
        valid_choice = false
      else
        puts "Invalid choice. Please try again.".red
      end
    end

    return player_choice
  end
  # maybe use is_integer? method?
  def get_valid_player_input(text_player_can_see, min_number, max_number)
    valid_input = false
    while !valid_input
      print text_player_can_see + " (#{min_number}-#{max_number})\n  :"
      player_input = gets.chomp
      if /\A\d+\z/.match?(player_input) && min_number <= player_input.to_i <= max_number
        valid_input = true
      else
        puts "Invalid input. Please enter number from #{min_number} to #{max_number}.".red
      end
    end

    return int(player_input)
  end

  def get_computer_choice
    CHOICES.sample
  end

  def determine_winner(player_choice, computer_choice)
    if player_choice == computer_choice
      return "It's a tie!"
    elsif GAME_OUTCOMES[player_choice].include? computer_choice
      @player_score += 1
      return "You win this round!"
    else
      @computer_score += 1
      return "Computer wins this round!"
    end
  end

  def is_rounds_equal_to_zero(self, is_human_playing, result, number_of_rounds_with_each_opponent, player_name,
                              computer_name)
    if !(result.include? "It's a tie!")
      @rounds -= 1
      if is_human_playing
        @round_against_computer += 1
      end
    end
    if @rounds == 0
      one_round_results = @print_tools.show_one_round_results(PLAYER_SCORE, COMPUTER_SCORE,
                                                                  number_of_rounds_with_each_opponent)
      @score_tools.update_scores(player_name, PLAYER_SCORE, computer_name,
                                      COMPUTER_SCORE)
      if is_human_playing
        puts one_round_results
        @round_against_computer = ROUND_AGAINST_COMPUTER
      end
      PLAYER_SCORE = 0
      COMPUTER_SCORE = 0
      @rounds = number_of_rounds_with_each_opponent

      return false
    end

    return true
  end

  def play_game()
    for i in 1..3
      puts CHOICES.join(', ')
      computer_choice = get_computer_choice
      puts "--NoT cheating '#{computer_choice}'"
      print "Input text: "
      player_choice = gets.chomp
      result = determine_winner(player_choice, computer_choice)
      puts result
    end
    puts "Player score #{@player_score} : Computer score #{@computer_score}"
    puts @player_score > @computer_score ? 'Player won' : 'AI won'
  end
end


# i = 0
# loop do
#   i += 1
#   print "I'm currently number #{i}” # a way to have ruby code in a string
#   break if i > 5
# end