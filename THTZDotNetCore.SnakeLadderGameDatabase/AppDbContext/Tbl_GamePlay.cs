namespace THTZDotNetCore.SnakeLadderGameDatabase.AppDbContext
{
    public class Tbl_GamePlay
    {
        public int GamePlayMoveId { get; set; }
        public int PlayerId { get; set; }
        public string GameCode { get; set; }
        public int DiceRoll { get; set; }
        public int Newposition { get; set; }
    }
}
