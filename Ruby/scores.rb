class Scores
  # attr_accessor reads and writes
  # attr_writer writes only
  attr_reader :player1
  attr_reader :player2
  attr_reader :score1
  attr_reader :score2
  def initialize(player1, score1, player2, score2)
    @player1 = player1
    @score1 = score1
    @player2 = player2
    @score2 = score2
  end
end
