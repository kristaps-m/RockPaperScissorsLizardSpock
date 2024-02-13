namespace ConsoleApp
{
    internal class Scores
    {
        public string Player1 { get; set; }
        public int Score1 { get; set; }
        public string Player2 { get; set; }
        public int Score2 { get; set; }
        public Scores(string player1, int score1, string player2, int score2)
        {
            Player1 = player1;
            Score1 = score1;
            Player2 = player2;
            Score2 = score2;
        }
    }
}
