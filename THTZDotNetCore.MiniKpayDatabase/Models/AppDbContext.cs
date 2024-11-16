using Microsoft.EntityFrameworkCore;

namespace THTZDotNetCore.MiniKpayDatabase.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblDeposit> TblDeposits { get; set; }
        public virtual DbSet<TblWithdraw> TblWithdraws { get; set; }
        public virtual DbSet<TblTransfer> TblTransfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=.;Initial Catalog=MiniKPay;User ID=sa;Password=sasa@123;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Tbl_User");

                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.MobileNumber).HasMaxLength(20);
                entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Pin).HasMaxLength(50);
                entity.Property(e => e.CreatedDate).HasMaxLength(10);
               
            });

            modelBuilder.Entity<TblDeposit>(entity =>
            {
                entity.HasKey(e => e.DepositId);

                entity.ToTable("Tbl_Deposit");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);
                entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");
               
            });

            modelBuilder.Entity<TblWithdraw>(entity =>
            {
                entity.HasKey(e => e.WithdrawId);

                entity.ToTable("Tbl_Withdraw");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);
                entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");
               
            });

            modelBuilder.Entity<TblTransfer>(entity =>
            {
                entity.HasKey(e => e.TransferId);

                entity.ToTable("Tbl_Transfer");

                entity.Property(e => e.FromMobileNumber ).HasMaxLength(50);
                entity.Property(e => e.ToMobileNumber).HasMaxLength(50);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Pin).HasMaxLength(50);
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}
