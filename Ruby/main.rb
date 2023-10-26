require_relative 'constants'
require_relative 'rock_paper_scissors_lizard_spock'

def foo
  puts "Hello This is Rock Paper and so on App!\n----------------"
  # puts GAME_OUTCOMES['rock']
  # puts CHOICES
end

if __FILE__ == $0
  foo
  game = RockPaperScissorsLizardSpock.new()
  game.play_game()
  # TESTS
  # puts game.get_computer_choice
  # bar()
end