using Microsoft.EntityFrameworkCore;


namespace MigrationProduct.Intake
{
    class ConnectMilkoscanIntake : DbContext
    {
        public DbSet<PredictionC> Prediction { get; set; }
        public DbSet<ProductC> Product { get; set; }
        public DbSet<SampleC> Sample { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=192.168.9.180;Initial Catalog=MSCFT1;User ID=sa;Password=15793;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PredictionC>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.SampRef,
                    e.RepNoRef,
                    e.CompRef
                });
            });

            modelBuilder.Entity<ProductC>(entity =>
            {
                entity.HasKey(e => e.ProdNo);
            });

            modelBuilder.Entity<SampleC>(entity =>
            {
                entity.HasKey(e => e.SampNo);
            });
        }
    }
}
