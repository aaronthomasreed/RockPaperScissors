using RockPaperScissors.Interfaces;
using RockPaperScissors.Models.Enums;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Models.Gamemodes
{
    internal class BigBangGamemode : IGamemode
    {
        public string Name { get; init; }
        public Dictionary<string, ShapeOption> Shapes { get; init; }

        public BigBangGamemode()
        {
            Name = "Big Bang";
            Shapes = new Dictionary<string, ShapeOption>
            {
                { "R", new ShapeOption(Shape.Rock, [Shape.Scissors, Shape.Lizard]) },
                { "P", new ShapeOption(Shape.Paper, [Shape.Rock, Shape.Spock]) },
                { "S", new ShapeOption(Shape.Scissors, [Shape.Paper, Shape.Lizard]) },
                { "L", new ShapeOption(Shape.Lizard, [Shape.Spock, Shape.Paper]) },
                { "X", new ShapeOption(Shape.Spock, [Shape.Rock, Shape.Scissors]) }
            };
        }
    }
}
