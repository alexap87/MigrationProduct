using Microsoft.EntityFrameworkCore;
using MigrationProduct.Bottling;
using MigrationProduct.Curd;
using MigrationProduct.Intake;

namespace MigrationProduct.MySQLMilkoscan
{
    class ConnectionMilkoscan : DbContext
    {
        public DbSet<PredictionC> prediction { get; set; }
        public DbSet<ProductC> product { get; set; }
        public DbSet<SampleC> sample { get; set; }
        public DbSet<DoubleComponentsC> doublecomponent { get; set; }
        public DbSet<TextComponentsC> textcomponent { get; set; }
        public DbSet<tblMfCdPredictedValueC> fsprediction { get; set; }
        public DbSet<tblMfCdProductC> fsproduct { get; set; }
        public DbSet<tblMfCdSampleC> fssample { get; set; }
        public DbSet<tblMfCdSubSampleC> fssubsample { get; set; }
        public DbSet<ResultsC> result { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("server=localhost;user id=ASUTP;password=15793;persistsecurityinfo=True;database=millkoscan;");
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

            modelBuilder.Entity<DoubleComponentsC>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.SampleIndex,
                    e.CID,
                    e.IntakeNumerator,
                    e.SyntheticNumerator,
                    e.WorkstationID
                });
            });

            modelBuilder.Entity<TextComponentsC>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.SampleIndex,
                    e.CID,
                    e.IntakeNumerator,
                    e.SyntheticNumerator,
                    e.WorkstationID
                });
            });

            modelBuilder.Entity<ResultsC>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.SampleIndex,
                    e.IntakeNumerator,
                    e.SyntheticNumerator,
                    e.WorkstationID
                });
            });

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
