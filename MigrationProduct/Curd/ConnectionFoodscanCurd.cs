using Microsoft.EntityFrameworkCore;

namespace MigrationProduct.Curd
{
    class ConnectionFoodscanCurd : DbContext
    {
        public DbSet<tblMfCdSampleC> tblMfCdSample { get; set; }
        public DbSet<tblMfCdPredictedValueC> tblMfCdPredictedValue { get; set; }
        public DbSet<tblMfCdProductC> tblMfCdProduct { get; set; }
        public DbSet<tblMfCdSubSampleC> tblMfCdSubSample { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=192.168.10.37;Initial Catalog=FoodScan2;Persist Security Info=True;User ID=sa;Password=15793;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<tblMfCdSampleC>(entity =>
            {
                entity.HasKey(e => e.SampleID);
            });
            modelBuilder.Entity<tblMfCdPredictedValueC>(entity =>
            {
                entity.HasKey(e => e.PredictedValueID);
            });
            modelBuilder.Entity<tblMfCdProductC>(entity =>
            {
                entity.HasKey(e => e.ProductID);
            });
            modelBuilder.Entity<tblMfCdSubSampleC>(entity =>
            {
                entity.HasKey(e => e.SubSampleID);
            });
        }
    }
}
