namespace ConsoleApp
{
    internal class PrintTools
    {
        public void PrintScores(Scores[][] scores)
        {
            foreach (var row in scores)
            {
                Console.WriteLine("----------------------------------------------------------------");
                foreach (var score in row)
                {
                    if (score != null)
                    {
                        Console.WriteLine($"{score.Player1} vs {score.Player2}: {score.Score1}-{score.Score2}");
                    }
                    else
                    {
                        Console.WriteLine("N/A");
                    }
                }
            }
        }
    }
}
