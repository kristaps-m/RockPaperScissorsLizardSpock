namespace ConsoleApp
{
    internal class RockPaperScissorsLizardSpock
    {

        public string PlayerName { get; private set; } = "'YOU!!'";
        public string WinAutomaticaly { get; private set; } = "no";
        public static string[] Choices { get; } = new string[] { "rock", "paper", "scissors", "lizard", "spock" };
        public static Dictionary<string, string[]> GameOutcomes { get; } = new Dictionary<string, string[]>()
{
            // rock beats (scissors and lizard)...
            {"rock", new string[]{ "scissors", "lizard"}},
            {"paper", new string[]{"rock", "spock"}},
            {"scissors", new string[]{"paper", "lizard"}},
            {"lizard", new string[]{"paper", "spock"}},
            {"spock", new string[]{"rock", "scissors" }},
        };
        private readonly Random rand = new Random();
        private int MinRoundsAndOpponents { get; } = 1;
        private int MaxOpponents { get; } = 9;
        private int MaxRounds { get; } = 5;
        public int PlayerScore { get; set; } = 0;
        public int ComputerScore { get; set; } = 0;
        public int Rounds { get; set; } = 0;
        public int RoundAgainstComputer { get; set; } = 1;
        public PrintTools PrintTools { get; private set; }
        public ScoreTools ScoreTools { get; private set; }
        public RockPaperScissorsLizardSpock(string humanPlayerName, string winAutomaticaly)
        {
            PlayerName = humanPlayerName;
            PrintTools = new PrintTools(humanPlayerName);
            ScoreTools = new ScoreTools(GameOutcomes, Choices, PlayerName);
            WinAutomaticaly = winAutomaticaly;
        }

        public string GetPlayerChoiseFromInput(int roundNumber)
        {
            bool validChoice = false;
            string playerChoice = "";
            while (!validChoice)
            {
                Console.Write($"It's round {roundNumber}. Enter your ({string.Join("/", Choices)}) choice : ");
                playerChoice = Console.ReadLine().ToLower();
                if (Choices.Contains(playerChoice))
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

        public string GetComputerChoice()
        {
            return Choices[rand.Next(0, Choices.Length)];
        }

        public int GetValidPlayerInput(string textPlayerCanSee, int minNumber, int maxNumber)
        {
            bool validChoice = false;
            var playerInputAsNumber = 0;
            while (!validChoice)
            {
                Console.Write($"{textPlayerCanSee} ({minNumber}-{maxNumber})\n  :");
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
                return $"{PrintTools.GreenColor}You win this round!{PrintTools.ResetColor}";
            }
            else
            {
                ComputerScore++;
                return $"{PrintTools.RedColor}Computer wins this round!{PrintTools.ResetColor}";
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
            if (Rounds == 0)
            {
                var oneRoundResults = PrintTools.ShowOneRoundResults(PlayerScore, ComputerScore, numberOfRoundsWithEachOpponent);
                ScoreTools.UpdateScores(playerName, PlayerScore, computerName, ComputerScore);

                if (isHumanPlaying)
                {
                    Console.WriteLine(oneRoundResults);
                    RoundAgainstComputer = 1;
                }

                PlayerScore = 0;
                ComputerScore = 0;
                Rounds = numberOfRoundsWithEachOpponent;

                return true;
            }

            return false;
        }

        public void PlayGame()
        {
            PrintTools.PrintBeginningOfGame(Choices, ScoreTools.Players);
            string playerName = ScoreTools.PlayerName;
            int numberOfOpponents = GetValidPlayerInput($"Enter number of computer players!",
                                                           MinRoundsAndOpponents, MaxOpponents);
            int numberOfRoundsWithEachOpponent = GetValidPlayerInput(
                $"Enter number of rounds with each opponent!", MinRoundsAndOpponents, MaxRounds);
            Rounds = numberOfRoundsWithEachOpponent;
            ScoreTools.CreateScoresList(numberOfOpponents);

            for (int gameNr = 1; gameNr <= numberOfOpponents; gameNr++)
            {
                Console.WriteLine($"\n\nThis is game {gameNr} against {ScoreTools.Players[gameNr]}");
                while (true)
                {
                    string computer_choice = GetComputerChoice();
                    string playerChoice = "";
                    if (WinAutomaticaly == "yes")
                    {
                        playerChoice = ScoreTools.AutomaticallyPickWinningMoveAgainstComputer(computer_choice);
                    }
                    else
                    {
                        playerChoice = GetPlayerChoiseFromInput(RoundAgainstComputer);
                    }
                    Console.WriteLine($"You chose: {playerChoice}");
                    Console.WriteLine($"Computer {ScoreTools.Players[gameNr]} chose: {computer_choice}");
                    string result = DetermineWinner(playerChoice, computer_choice);
                    Console.WriteLine(result);
                    // Print scores after each move for testing. If so then comment line 119 (UpdateScores)
                    //ScoreTools.UpdateScores(playerName, PlayerScore, ScoreTools.Players[gameNr], ComputerScore);
                    //PrintTools.PrintScores(new List<List<Scores>>() { ScoreTools.Scores[0] });

                    if (IsRoundsEqualToZero(true, result, numberOfRoundsWithEachOpponent,
                                            playerName, ScoreTools.Players[gameNr]))
                    {
                        break;
                    }
                }
            }

            // remaining computers play against each other
            for (int computerGameIndex = 1; computerGameIndex <= numberOfOpponents; computerGameIndex++)
            {
                string computerMainPlayerName = ScoreTools.Players[computerGameIndex];
                for (int computerOpponentIndex = 1 + computerGameIndex; computerOpponentIndex <= numberOfOpponents; computerOpponentIndex++)
                {
                    string cpuPlayedAgainstName = ScoreTools.Players[computerOpponentIndex];
                    while (true)
                    {
                        string computerMainPlayerChoice = GetComputerChoice();
                        string cpuPlayedAgainstChoice = GetComputerChoice();
                        string result = DetermineWinner(
                            computerMainPlayerChoice, cpuPlayedAgainstChoice);

                        if (IsRoundsEqualToZero(false, result, numberOfRoundsWithEachOpponent,
                                                computerMainPlayerName, cpuPlayedAgainstName))
                        {
                            break;
                        }
                    }
                }
            }

            PrintTools.PrintScores(ScoreTools.Scores);
            ScoreTools.CountGamesWonForEachPlayer(numberOfOpponents);
            Console.WriteLine("-------");
            ScoreTools.SortAndPrintPlayerNamesAndGamesWon();

            if (ScoreTools.HaveYouWonTheGameWithMostWins())
            {
                Console.WriteLine($"\nYou won all {numberOfOpponents} computer opponents!\nCongratulations!");
            }
            else
            {
                Console.WriteLine("\nYou lost against computer!");
            }
        }
    }
}
