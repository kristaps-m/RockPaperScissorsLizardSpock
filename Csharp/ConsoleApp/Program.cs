// See https,//aka.ms/new-console-template for more information
Console.WriteLine("Hello RockPaperScissorsLizardSpock");


Dictionary<string, string[]> GAME_OUTCOMES = new Dictionary<string, string[]>()
{
    // rock beats (scissors and lizard)...
    {"rock", new string[]{ "scissors", "lizard"}},
    {"paper",  new string[]{"rock", "spock"}},
    {"scissors",  new string[]{"paper", "lizard"}},
    {"lizard",  new string[]{"paper", "spock"}},
    {"spock",  new string[]{ "rock", "scissors" }},
};

Console.WriteLine(string.Join(", ", GAME_OUTCOMES["rock"]));
Console.Write("Player enter Rock Paper Scissors Lizard Spock: ");
var myInput = Console.ReadLine();
var computerInput = "lizard";

if (GAME_OUTCOMES[myInput.ToLower()].Contains(computerInput))
{
    Console.WriteLine($"Player WON with: {myInput}");
}
else
{
    Console.WriteLine("PC WON!");
}