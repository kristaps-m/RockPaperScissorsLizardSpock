require_relative 'constants'

class PrintTools

  def print_scores(scores)
    #for row in scores
    scores.each do |row|
      puts "----------------------------------------------------------------"
      row.each do |score|
      #for score in row
        if !score.nil?
          puts "#{score.player1} vs #{score.player2}: #{score.score1}-#{score.score2}"
        else
          puts "N/A"
        end
      end
    end
  end

  def show_one_round_results(player_score, computer_score, number_of_rounds)
    result_start = "After #{number_of_rounds} rounds "
    result_end = "\nResult [You - #{player_score} : CPU - #{computer_score}]"

    if player_score == computer_score
      return result_start + "it's a tie!" + result_end
    elsif player_score > computer_score
      return result_start + "Player wins!" + result_end
    else
      return result_start + "Computer wins!" + result_end
    end
  end
  # array.map { |string| string.upcase } --- ', '.join(i.capitalize() for i in choices)
  # ', '.join(computer_names[1:])
  def print_beginning_of_game(choices, computer_names)
    puts "Welcome to #{choices.map {|ch| ch.capitalize}.join(', ')}"
    puts "You can play the game against computer players. And they will play against each other."
    puts "Their names are #{computer_names[1, computer_names.length].join(', ')}!"
    puts "You can pick how many opponents to play and how many rounds against them!"
  end
end