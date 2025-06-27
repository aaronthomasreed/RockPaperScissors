using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Interfaces
{
    internal interface IGamemode : IPromptOption
    {
        Dictionary<string, ShapeOption> Shapes { get; init; }
    }
}
