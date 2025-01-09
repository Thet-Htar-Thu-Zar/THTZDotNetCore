namespace THTZDotNetCore.SnakeLadderGameDatabase.AppDbContext
{
    public class Tbl_Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int CurrentPosition { get; set; }
    }
}
