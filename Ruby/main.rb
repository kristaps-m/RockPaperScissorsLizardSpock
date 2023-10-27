require 'colorize'
require_relative 'constants'
require_relative 'rock_paper_scissors_lizard_spock'
require_relative 'print_tools'
require_relative 'score_tools'

def foo
  puts "Hello This is Rock Paper and so on App!\n----------------"
  # puts GAME_OUTCOMES['rock']
  # puts CHOICES
  # puts "I am now red".red
  # puts "I am now blue".blue
  # puts "Testing".yellow
  # puts 'Is this green?'.green
  # puts "What colors is this".green + "Is this red?".red
  # pt = PrintTools.new()
  # pt.print_beginning_of_game(CHOICES, GAME_PARTICIPANTS_NAMES)
  st = ScoreTools.new()
  st.create_scores_list(6)
  st.generate_player_names_and_games_won_dictionary(6)
  puts st.ret_shet
end

if __FILE__ == $0
  foo
  game = RockPaperScissorsLizardSpock.new()
  game.play_game()
  # TESTS
  # puts game.get_computer_choice
  # bar()
end