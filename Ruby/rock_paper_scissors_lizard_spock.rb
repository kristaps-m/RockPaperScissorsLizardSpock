require_relative 'constants.rb'

class RockPaperScissorsLizardSpock
  def initialize()
    @player_score = 0
    @computer_score = 0
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