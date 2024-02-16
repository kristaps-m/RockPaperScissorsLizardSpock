using ConsoleApp;
Console.Write("Welcome To The Game! Enter your name: ");
var userName = Console.ReadLine();
Console.Write("Do you want to win automaticaly? ('yes' - 'no'): ");
var winAutomaticaly = Console.ReadLine().ToLower();
var rpsls = new RockPaperScissorsLizardSpock(userName, winAutomaticaly);
rpsls.PlayGame();
