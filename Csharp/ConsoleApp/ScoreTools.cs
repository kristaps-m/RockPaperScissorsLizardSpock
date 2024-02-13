using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp
{
    internal class ScoreTools
    {
        public List<List<Scores>> Scores { get; set; }
        public static string PlayerName = "'YOU!!'";
        public string[] Players { get; } = new string[] { PlayerName, "'Call of Blanked'", "'Vintage Vegan'", "'Lean fat'",
                           "'Average Taste'", "'Terminator'", "'Super man'",
                           "'Premium Princess'", "'Fat KitKat'", "'Bald Egg'"};
        // {"'YOU!!'": 9, "'Call of Blanked'": 4, "'Vintage Vegan'": 4, "'Lean fat'": 3, "'Average Taste'": 3, "'Terminator'": 5, "'Super man'": 5, "'Premium Princess'": 8, "'Fat KitKat'": 1, "'Bald Egg'": 3}
        public Dictionary<string, int> PlayerNamesAndGamesWon { get; set; }
        public PrintTools PrintTools { get; set; } = new PrintTools();
        //private RockPaperScissorsLizardSpock rpsls = new RockPaperScissorsLizardSpock();

        public void CreateScoresList(int numPlayers)
        {
            for (int i = 0; i <= numPlayers; i++)
            {
                Scores.Add(new List<Scores>());
                for (int j = 0; j <= numPlayers; j++)
                {
                    if (i != j)
                    {
                        Scores[i].Add(new Scores(Players[i], 0, Players[j], 0));
                    }
                    else
                    {
                        Scores[i].Add(null);
                    }
                }
            }
        }

        public void GeneratePlayerNamesAndGamesWonDictionary(int numberOfOpponents)
        {
            //Console.WriteLine(PlayerNamesAndGamesWon); // Assuming PlayerNamesAndGamesWon is already initialized
            PlayerNamesAndGamesWon = new Dictionary<string, int>();
            foreach (var player in Players.Take(numberOfOpponents + 1))
            {
                PlayerNamesAndGamesWon[player] = 0;
            }
        }

        public void CountGamesWonForEachPlayer(int numberOfOpponents)
        {
            //Console.WriteLine(scores); // Assuming scores is already initialized
            GeneratePlayerNamesAndGamesWonDictionary(numberOfOpponents);
            foreach (var row in Scores)
            {
                foreach (var score in row)
                {
                    if (score != null && score.Score1 > score.Score2)
                    {
                        PlayerNamesAndGamesWon[score.Player1]++;
                    }
                }
            }
        }

        public void SortAndPrintPlayerNamesAndGamesWon()
        {
            var sortedDict = PlayerNamesAndGamesWon.OrderByDescending(x => x.Value)
                                                    .ToDictionary(x => x.Key, x => x.Value);
            int maxNameLength = sortedDict.Keys.Max(name => name.Length);

            PrintTools.PrintPlayerNameAndVictories(sortedDict, maxNameLength);
        }


        public bool HaveYouWonTheGameWithMostWins()
        {
            Console.WriteLine(PlayerNamesAndGamesWon);
            int maxWinScore = PlayerNamesAndGamesWon.Values.Max();
            int howManyPlayersHaveMaxScore = 0;
            bool hasPlayerMaxScore = PlayerNamesAndGamesWon.ContainsKey(PlayerName) && PlayerNamesAndGamesWon[PlayerName] == maxWinScore;

            foreach (var v in PlayerNamesAndGamesWon.Values)
            {
                if (maxWinScore == v)
                {
                    howManyPlayersHaveMaxScore++;
                }
            }

            return howManyPlayersHaveMaxScore == 1 && hasPlayerMaxScore;
        }

        public void UpdateScores(string p1, int s1, string p2, int s2)
        {
            var index1 = Array.IndexOf(Players, p1);
            var index2 = Array.IndexOf(Players, p2);
            Scores[index1][index2] = new Scores(p1, s1, p2, s2);
            Scores[index2][index1] = new Scores(p2, s2, p1, s1);
        }

        //public string AutomaticallyPickWinningMoveAgainstComputer(string computerChoice)
        //{
        //    List<string> notPickToWin = new List<string>(rpsls.GameOutcomes[computerChoice]);
        //    notPickToWin.Add(computerChoice);
        //    List<string> winningChoices = rpsls.Choices.Except(notPickToWin).ToList();
        //    Random random = new Random();
        //    string randomWinningChoice = winningChoices[random.Next(winningChoices.Count)];

        //    return randomWinningChoice;
        //}

    }
}
