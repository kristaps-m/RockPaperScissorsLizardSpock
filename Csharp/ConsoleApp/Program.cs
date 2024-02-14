using ConsoleApp;
Console.Write("Welcome To The Game! Enter your name: ");
var userName = Console.ReadLine();
var rpsls = new RockPaperScissorsLizardSpock(userName);
rpsls.PlayGame();
