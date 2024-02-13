namespace ConsoleApp
{
    internal class RockPaperScissorsLizardSpock
    {
        public string[] Choises { get; } = new string[] { "rock", "paper", "scissors", "lizard", "spock" };
        public Dictionary<string, string[]> GameOutcomes { get; } = new Dictionary<string, string[]>()
{
            // rock beats (scissors and lizard)...
            {"rock", new string[]{ "scissors", "lizard"}},
            {"paper", new string[]{"rock", "spock"}},
            {"scissors", new string[]{"paper", "lizard"}},
            {"lizard", new string[]{"paper", "spock"}},
            {"spock", new string[]{"rock", "scissors" }},
        };
        private readonly Random rand = new Random();
        public int PlayerScore { get; set; } = 0;
        public int ComputerScore { get; set; } = 0;
        public int Rounds { get; set; } = 0;
        public int RoundAgainstComputer { get; set; } = 1;

        public string GetPlayerChoiseFromInput(int roundNumber)
        {
            bool validChoice = false;
            string playerChoice = "";
            while (!validChoice)
            {
                Console.WriteLine($"It's round {roundNumber}. Enter your ({string.Join("/", Choises)}) choice : ");
                playerChoice = Console.ReadLine().ToLower();
                if (Choises.Contains(playerChoice))
                {
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            return playerChoice;
        }

        public string GetComputerChoise()
        {
            return Choises[rand.Next(0, Choises.Length)];
        }

        public int GetValidPlayerInput(string textPlayerCanSee, int minNumber, int maxNumber)
        {
            bool validChoice = false;
            var playerInputAsNumber = 0;
            while (!validChoice)
            {
                Console.WriteLine($"{textPlayerCanSee}. ({minNumber}-{maxNumber})");
                string? playerInput = Console.ReadLine();
                bool canConvert = byte.TryParse(playerInput, out byte i);
                playerInputAsNumber = canConvert ? int.Parse(playerInput) : 1;
                if (canConvert && minNumber <= playerInputAsNumber && playerInputAsNumber <= maxNumber)
                {
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter number from {minNumber} to {maxNumber}.");
                }
            }

            return playerInputAsNumber;

        }

        public string DetermineWinner(string player, string computer)
        {
            if (player == computer)
            {
                return "It's a tie!";
            }
            else if (GameOutcomes[player].Contains(computer))
            {
                PlayerScore++;
                return "You win this round!";
            }
            else
            {
                ComputerScore++;
                return "Computer wins this round!";
            }
        }

        public bool IsRoundsEqualToZero(bool isHumanPlaying, string result,
            int numberOfRoundsWithEachOpponent, string playerName, string computerName)
        {
            if (result.Contains("It's a tie!") == false)
            {
                Rounds--;
                if (isHumanPlaying)
                {
                    RoundAgainstComputer++;
                }
            }
            if(Rounds == 0)
            {
                var oneRoundResults = 
            }

            return true;
        }
    }
}
