// See https,//aka.ms/new-console-template for more information
using ConsoleApp;

var rpsls = new RockPaperScissorsLizardSpock();
rpsls.PlayGame();

//Console.WriteLine($"Hello {string.Join(", ", rpsls.Choices)}");
//var numberOfRounds = rpsls.GetValidPlayerInput("Min and max round", 1, 3);
//var humanWins = 0;
//var computerWins = 0;


//while (numberOfRounds > 0)
//{
//    var computerInput = rpsls.GetComputerChoice();
//    Console.WriteLine(computerInput);
//    string myInput = rpsls.GetPlayerChoiseFromInput(numberOfRounds);
//    if (rpsls.GameOutcomes[myInput].Contains(computerInput))
//    {
//        Console.WriteLine($"Player WON round: {myInput}");
//        humanWins++;
//        numberOfRounds--;
//    }
//    else
//    {
//        Console.WriteLine($"PC WON round! {computerInput}");
//        computerWins++;
//        numberOfRounds--;
//    }
//}

//if (humanWins > computerWins)
//{
//    Console.WriteLine("You won!");
//}
//else
//{
//    Console.WriteLine("Computer wins!");
//}