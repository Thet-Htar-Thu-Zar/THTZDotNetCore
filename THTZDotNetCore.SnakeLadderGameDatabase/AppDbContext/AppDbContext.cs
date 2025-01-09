using Microsoft.EntityFrameworkCore;

namespace THTZDotNetCore.SnakeLadderGameDatabase.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Tbl_Game> TblGames { get; set; }

        public virtual DbSet<Tbl_GamePlay> TblGamePlays { get; set; }

        public virtual DbSet<Tbl_Player> TblPlayers { get; set; }

    }
}
