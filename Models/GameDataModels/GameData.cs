namespace RockPaperScissors.Models.GameDataModels
{
    internal class GameData
    {
        public int WinCondition { get; init; }
        
        public Player Human { get; init; }
        public Player Computer { get; init; }

        public List<GameTurn> Turns { get; set; } = new List<GameTurn>();
        public int HumanPoints => Turns.Where(n => n.Winner == Human).Count();
        public int ComputerPoints => Turns.Where(n => n.Winner == Computer).Count();
        public int CompletedTurns => Turns.Count;
        
        public GameData(int winCondition)
        {
            Human = new Player("Human");
            Computer = new Player("Computer");
            WinCondition = winCondition;
        }

        public int GetRoundNumber()
            => CompletedTurns + 1;

        public GameTurn? GetPreviousTurn()
        {
            var previousIndex = Turns.Count() - 1;

            if (previousIndex > -1) {
                return Turns[previousIndex];
            }

            return null;
        }

        public Player? Winner
        {
            get
            {
                if (HumanPoints >= WinCondition)
                    return Human;
                else if (ComputerPoints >= WinCondition)
                    return Computer;
                else
                    return null;
            }
        }

        public bool HasWinner => Winner != null;
    }
}
