#import random
require_relative 'constants'
require_relative 'scores'
require_relative 'print_tools'

class ScoreTools
  def initialize
    @players = GAME_PARTICIPANTS_NAMES
    @scores = []
    @player_names_and_games_won = {}
    @print_tools = PrintTools.new()
  end

  def create_scores_list(num_players)
    #for i in range(num_players + 1)
    for i in 0..num_players
      @scores.push([])
      for j in 0..num_players #range(num_players + 1)
        if i != j
          @scores[i].push(Scores.new(@players[i], 0, @players[j], 0))
        else
          @scores[i].push(nil)
        end
      end
    end
  end

  def generate_player_names_and_games_won_dictionary(number_of_opponents)
    #@player_names_and_games_won = {k: 0 for k in @players[:number_of_opponents + 1]}
    @players[0, number_of_opponents + 1].each do |key|
      @player_names_and_games_won[key] = 0
    end
  end

  def count_games_won_for_each_player(number_of_opponents)
    generate_player_names_and_games_won_dictionary(number_of_opponents)
    #for row in @scores
    @scores.each do |row|
      #for score in row
      row.each do |score|
        if !score.nil? && score.score1 > score.score2
          @player_names_and_games_won[score.player1] += 1
        end
      end
    end
  end

  def sort_and_print_player_names_and_games_won
    # sorted_dict = dict(sorted(self.player_names_and_games_won.items(), key=lambda x: x[1], reverse=True))
    # max_name_length = max(len(name) for name in sorted_dict.keys())
    sorted_dict = Hash[@player_names_and_games_won.sort_by { |k, v| v }.reverse]
    max_name_length = sorted_dict.keys.max_by { |name| name.length }.length

    @print_tools.print_player_name_and_victories(sorted_dict, max_name_length)
  end

  def have_you_won_the_game_with_most_wins # does this need ? @ end
    max_win_score = @player_names_and_games_won.values.max
    how_many_players_have_max_score = 0
    has_player_max_score = @player_names_and_games_won[PLAYER_NAME] == max_win_score

    #for v in @player_names_and_games_won.values
    @player_names_and_games_won.values.each do |v|
      if max_win_score == v
        how_many_players_have_max_score += 1
      end
    end

    return how_many_players_have_max_score == 1 && has_player_max_score ? true : false
  end

  # is this the best way to get index?
  def update_scores(player1, score1, player2, score2)
    index1 = @players.index(player1)
    index2 = @players.index(player2)
    @scores[index1][index2] = Scores.new(player1, score1, player2, score2)
    @scores[index2][index1] = Scores.new(player2, score2, player1, score1)
  end

  # def automatically_pick_winning_move_against_computer(self, computer_choice):
  #   not_pick_to_win = constants.GAME_OUTCOMES[computer_choice]
  #   not_pick_to_win.append(computer_choice)
  #   winning_choices = [c for c in constants.CHOICES if c not in not_pick_to_win]
  #   random_winning_choice = random.choice(winning_choices)

  #   return random_winning_choice

  def ret_shet
    return "#{@player_names_and_games_won},\n\n #{@scores}"
  end

  def get_scores
    @scores
  end
end