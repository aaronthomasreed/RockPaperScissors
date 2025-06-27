using RockPaperScissors.Models;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Interfaces
{
    internal interface IOpponent : IPromptOption
    {
        ShapeOption GetMove(Game game);
    }
}
