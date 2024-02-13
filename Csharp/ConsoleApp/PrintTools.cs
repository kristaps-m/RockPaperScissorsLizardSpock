namespace ConsoleApp
{
    internal class PrintTools
    {
        public void PrintScores(List<List<Scores>> scores)
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

        public string ShowOneRoundResults(int playerScore, int computerScore, int numberOfRounds)
        {
            var resultStart = $"After {numberOfRounds} rounds ";
            var resultEnd = $"\nResulst [You - {playerScore} : CPU - {computerScore}";

            if(playerScore == computerScore)
            {
                return resultStart + "it's a tie!" + resultEnd;
            }
            else if (playerScore > computerScore)
            {
                return resultStart + "Player wins!" + resultEnd;
            }
            else
            {
                return resultStart + "Computer wins!" + resultEnd;
            }
        }

        // PrintBeginningOfGame()
        public void PrintBeginningOfGame(string[] choices, string[] computerNames)
        {
            Console.WriteLine($"Welcome to {string.Join(", ", choices.Select(i => i.First().ToString().ToUpper() + i.Substring(1)))}");
            Console.WriteLine("You can play the game against computer players. And they will play against each other.");
            Console.WriteLine($"Their names are {string.Join(", ", computerNames.Skip(1))}!");
            Console.WriteLine("You can pick how many opponents to play and how many rounds against them!");
        }

        // PrintPlayerNameAndVictories()
        public class Constants
        {
            public const string PlayerName = "PLAYER_NAME";
            public const string GreenColor = "\u001b[32m";
            public const string ResetColor = "\u001b[0m";
        }
        public void PrintPlayerNameAndVictories(Dictionary<string, int> sortedDict, int maxNameLength)
        {
            foreach (var kvp in sortedDict)
            {
                string name = kvp.Key;
                int wins = kvp.Value;
                string paddedName = name.PadRight(maxNameLength, '.');

                if (paddedName.Contains(Constants.PlayerName))
                {
                    Console.WriteLine($"Player: {Constants.GreenColor}{paddedName}{Constants.ResetColor} Wins: {wins}");
                }
                else
                {
                    Console.WriteLine($"Player: {paddedName} Wins: {wins}");
                }
            }
        }
    }
}
