namespace ConsoleApp
{
    internal class RockPaperScissorsLizardSpock
    {

        public string PlayerName { get; private set; } = "'YOU!!'";
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
        public RockPaperScissorsLizardSpock(string humanPlayerName)
        {
            PlayerName = humanPlayerName;
            PrintTools = new PrintTools(humanPlayerName);
            ScoreTools = new ScoreTools(GameOutcomes, Choices, PlayerName);
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
            string player_name = ScoreTools.PlayerName;
            int number_of_opponents = GetValidPlayerInput($"Enter number of computer players!",
                                                           MinRoundsAndOpponents, MaxOpponents);
            int number_of_rounds_with_each_opponent = GetValidPlayerInput(
                $"Enter number of rounds with each opponent!", MinRoundsAndOpponents, MaxRounds);
            Rounds = number_of_rounds_with_each_opponent;
            ScoreTools.CreateScoresList(number_of_opponents);

            for (int game_nr = 1; game_nr <= number_of_opponents; game_nr++)
            {
                Console.WriteLine($"\n\nThis is game {game_nr} against {ScoreTools.Players[game_nr]}");
                while (true)
                {
                    string computer_choice = GetComputerChoice();
                    string player_choice = ScoreTools.AutomaticallyPickWinningMoveAgainstComputer(computer_choice);
                    // string player_choice = GetPlayerChoiseFromInput(RoundAgainstComputer);
                    Console.WriteLine($"You chose: {player_choice}");
                    Console.WriteLine($"Computer {ScoreTools.Players[game_nr]} chose: {computer_choice}");
                    string result = DetermineWinner(player_choice, computer_choice);
                    Console.WriteLine(result);

                    if (IsRoundsEqualToZero(true, result, number_of_rounds_with_each_opponent,
                                            player_name, ScoreTools.Players[game_nr]))
                    {
                        break;
                    }
                }
            }

            // remaining computers play against each other
            for (int computer_game_index = 1; computer_game_index <= number_of_opponents; computer_game_index++)
            {
                string computer_main_player_name = ScoreTools.Players[computer_game_index];
                for (int computer_opponent_index = 1 + computer_game_index; computer_opponent_index <= number_of_opponents; computer_opponent_index++)
                {
                    string cpu_played_against_name = ScoreTools.Players[computer_opponent_index];
                    while (true)
                    {
                        string computer_main_player_choice = GetComputerChoice();
                        string cpu_played_against_choice = GetComputerChoice();
                        string result = DetermineWinner(
                            computer_main_player_choice, cpu_played_against_choice);

                        if (IsRoundsEqualToZero(false, result, number_of_rounds_with_each_opponent,
                                                computer_main_player_name, cpu_played_against_name))
                        {
                            break;
                        }
                    }
                }
            }

            PrintTools.PrintScores(ScoreTools.Scores);
            ScoreTools.CountGamesWonForEachPlayer(number_of_opponents);
            Console.WriteLine("-------");
            ScoreTools.SortAndPrintPlayerNamesAndGamesWon();

            if (ScoreTools.HaveYouWonTheGameWithMostWins())
            {
                Console.WriteLine($"\nYou won all {number_of_opponents} computer opponents!\nCongratulations!");
            }
            else
            {
                Console.WriteLine("\nYou lost against computer!");
            }
        }
    }
}
