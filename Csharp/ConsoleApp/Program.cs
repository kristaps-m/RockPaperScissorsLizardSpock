// See https,//aka.ms/new-console-template for more information
using ConsoleApp;

var rpsls = new RockPaperScissorsLizardSpock();

Console.WriteLine($"Hello {string.Join(", ", rpsls.Choises)}");
var numberOfRounds = rpsls.GetValidPlayerInput("Min and max round", 1, 3);
var humanWins = 0;
var computerWins = 0;


while (numberOfRounds > 0)
{
    var computerInput = rpsls.GetComputerChoise();
    Console.WriteLine(computerInput);
    string myInput = rpsls.GetPlayerChoiseFromInput(numberOfRounds);
    if (rpsls.GameOutcomes[myInput].Contains(computerInput))
    {
        Console.WriteLine($"Player WON round: {myInput}");
        humanWins++;
        numberOfRounds--;
    }
    else
    {
        Console.WriteLine($"PC WON round! {computerInput}");
        computerWins++;
        numberOfRounds--;
    }
}

if (humanWins > computerWins)
{
    Console.WriteLine("You won!");
}
else
{
    Console.WriteLine("Computer wins!");
}