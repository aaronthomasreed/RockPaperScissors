using RockPaperScissors.Interfaces;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Models.Opponents
{
    internal class RandomMoveOpponent : IOpponent
    {
        public string PromptName { get; init; }

        public string Name { get; init; }
        internal RandomMoveOpponent()
        {
            PromptName = "Standard";
            Name = "Standard";
        }

        public ShapeOption GetMove(Game game)
        {
            var options = game.Gamemode.Shapes.Select(s => s.Value).ToList();

            Random random = new Random();
            var resultIndex = random.Next(0, options.Count - 1);

            return options[resultIndex];
        }
    }
}
