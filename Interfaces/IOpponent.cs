using RockPaperScissors.Models;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Interfaces
{
    internal interface IOpponent : IPromptOption
    {
        string Name { get; init; }

        ShapeOption GetMove(Game game);
    }
}
