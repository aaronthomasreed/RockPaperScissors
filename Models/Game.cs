using RockPaperScissors.Interfaces;
using RockPaperScissors.Models.GameDataModels;

namespace RockPaperScissors.Models
{
    internal class Game
    {
        public IGamemode Gamemode { get; init; }

        private GameData Data { get; set; }

        public static readonly int WinCondition = 3;
        public IOpponent Opponent { get; set; }

        public Game(IGamemode gamemode, IOpponent opponent)
        {
            Gamemode = gamemode;
            Opponent = opponent;
            Data = new GameData(WinCondition);
        }

        public void Start()
        {
            ProcessTurn();
        }

        public GameTurn? GetPreviousTurn()
           => Data.GetPreviousTurn();

        public void ProcessTurn()
        {
            Console.WriteLine($"Round {Data.GetRoundNumber()} - First to {WinCondition} wins!");
            Console.WriteLine($"Current score: Player ({Data.HumanPoints}) - Computer ({Data.ComputerPoints}) \n\r");

            var turnResult = PlayTurn();
            Data.Turns.Add(turnResult);

            if (!Data.HasWinner)
            {
                ProcessTurn();
                return;
            }
            else
            {
                Console.WriteLine($"{Data.Winner.Name} has won!");
                return;
            }
        }

        private GameTurn PlayTurn()
        {
            GameTurn turn = new GameTurn();

            var computerMove = Opponent.GetMove(this);
            var playerMove = PromptPlayerMove();

            turn.PlayerMove = playerMove;
            turn.ComputerMove = computerMove;

            if (playerMove.BeatsShape(computerMove.Shape))
            {
                turn.Winner = Data.Human;
                Console.WriteLine($"+1 to the Player - {playerMove.Name} beats {computerMove.Name} \n\r");
            }
            else if (computerMove.BeatsShape(playerMove.Shape))
            {
                turn.Winner = Data.Computer;
                Console.WriteLine($"+1 to the Computer - {computerMove.Name} beats {playerMove.Name} \n\r");
            }
            else
            {
                Console.WriteLine($"It's a draw! You both chose {playerMove.Name}! \n\r");
            }

            return turn;
        }

        private ShapeOption PromptPlayerMove()
        {
            Console.WriteLine("Choose your move: ");
            Console.WriteLine(string.Join(", ", Gamemode.Shapes.Select(s => $"[{s.Key}] - {s.Value.Name}")));

            var input = Console.ReadLine();

            if (!Gamemode.Shapes.TryGetValue(input.ToUpper(), out var option))
            {
                Console.WriteLine("Invalid selection for move! Please try again.");
                return PromptPlayerMove();
            }

            return option;
        }
    }
}
