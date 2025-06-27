using RockPaperScissors.Interfaces;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Models.Opponents
{
    internal class PreviousMoveOpponent : IOpponent, IPromptOption
    {
        public string Name { get; init; }

        public ShapeOption GetMove(Game game)
        {
            var playersPreviousMove = game.GetPreviousTurn()?.PlayerMove;

            // if turn has not yet been played, pick a random move.
            if (playersPreviousMove == null)
            {
                var randomOpponent = new RandomMoveOpponent();

                return randomOpponent.GetMove(game);
            }

            return playersPreviousMove;
        }

        public PreviousMoveOpponent()
        {
            Name = "Previous Move";
        }
    }
}
