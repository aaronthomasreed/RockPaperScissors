namespace RockPaperScissors.Models.GameDataModels
{
    internal class GameTurn
    {
        public int TurnNumber { get; set; }
        public ShapeOption PlayerMove {  get; set; }
        public ShapeOption ComputerMove { get; set; }

        public Player Winner { get; set; }
    }
}
