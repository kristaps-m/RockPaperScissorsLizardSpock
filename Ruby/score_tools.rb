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
    #@player_names_and_games_won = {k: 0 for k in @players[number_of_opponents + 1]}
    @players[0, number_of_opponents].each do |key|
      @player_names_and_games_won[key] = 0
    end
  end

  def ret_shet
    return "#{@player_names_and_games_won},\n\n #{@scores}"
  end
end