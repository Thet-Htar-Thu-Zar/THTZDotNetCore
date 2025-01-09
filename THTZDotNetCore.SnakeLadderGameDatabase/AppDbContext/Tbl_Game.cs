using System.ComponentModel.DataAnnotations;

namespace THTZDotNetCore.SnakeLadderGameDatabase.AppDbContext
{
    public class Tbl_Game
    {
        [Key]
        public int GameId { get; set; }
        public string GameCode { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime EndTime { get; set; } = DateTime.UtcNow;
        public int? WinnerID { get; set; }
    }
}
