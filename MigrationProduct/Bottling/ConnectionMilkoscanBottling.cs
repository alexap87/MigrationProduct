using Microsoft.EntityFrameworkCore;

namespace MigrationProduct.Bottling
{
    public class ConnectionMilkoscanBottling: DbContext
    {
        public DbSet<TextComponentsC> TextComponents { get; set; }
        public DbSet<DoubleComponentsC> DoubleComponents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=192.168.8.64;Initial Catalog=FIBASE2;Persist Security Info=True;User ID=sa;Password=15793");

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DoubleComponentsC>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.WorkstationID,
                    e.SampleIndex,
                    e.IntakeNumerator,
                    e.SyntheticNumerator,
                    e.CID
                });
            });

            modelBuilder.Entity<TextComponentsC>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.WorkstationID,
                    e.SampleIndex,
                    e.IntakeNumerator,
                    e.SyntheticNumerator,
                    e.CID
                });
            });
        }
    }
}
