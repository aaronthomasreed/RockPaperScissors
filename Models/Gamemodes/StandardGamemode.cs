using RockPaperScissors.Interfaces;
using RockPaperScissors.Models.Enums;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Models.Gamemodes
{
    internal class StandardGamemode : IGamemode
    {
        public string Name { get; init; }
        public Dictionary<string, ShapeOption> Shapes { get; init; }

        public StandardGamemode()
        {
            Name = "Standard";
            Shapes = new Dictionary<string, ShapeOption>
            {
                { "R", new ShapeOption(Shape.Rock, [Shape.Scissors]) },
                { "P", new ShapeOption(Shape.Paper, [Shape.Rock]) },
                { "S", new ShapeOption(Shape.Scissors, [Shape.Paper]) }
            };
        }
    }
}
