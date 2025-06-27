// See https://aka.ms/new-console-template for more information
using RockPaperScissors;
using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using RockPaperScissors.Models.Gamemodes;
using RockPaperScissors.Models.Opponents;

var gamemodes = new Dictionary<string, IGamemode>
{
    { "1", new StandardGamemode() }, 
    { "2", new BigBangGamemode() }
};

var opponents = new Dictionary<string, IOpponent>
{
    { "1", new RandomMoveOpponent() },
    { "2", new PreviousMoveOpponent() },
};

PlayGame();

return 0;

void PlayGame()
{
    Console.WriteLine("Welcome to: Rock, Paper, Scissors!");
    Console.WriteLine("Press enter to begin.");
    Console.ReadLine();

    IGamemode gamemode;
    IOpponent opponent;

    try
    {
        gamemode = PromptChooseGamemode();
        opponent = PromptChooseOpponent();
    }
    catch (Exception ex)
    {
        // Here I would log the exception via a Logger service
        Console.WriteLine("Oops, there has been a problem.");
        return;
    }
    

    Game game = new(gamemode, opponent);
    game.Start();

    Console.WriteLine("Do you want to play again?");

    if (PromptHelper.PromptBoolean())
        PlayGame();
    else
        Console.WriteLine("Thank you for playing!");
}

IGamemode PromptChooseGamemode()
    => PromptHelper.PromptAction(gamemodes, "game mode")!;

IOpponent PromptChooseOpponent()
    => PromptHelper.PromptAction(opponents, "opponent")!;
