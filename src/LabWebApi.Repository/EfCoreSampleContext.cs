using LabWebApi.Repository.Configurations;
using LabWebApi.Repository.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

#nullable disable

namespace LabWebApi.Repository
{
    public partial class EfcoreSampleContext : DbContext
    {
        public EfcoreSampleContext()
        {
        }

        public EfcoreSampleContext(DbContextOptions<EfcoreSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbFirstTable> DbFirstTables { get; set; }
        public virtual DbSet<EditInfo> EditInfos { get; set; }
        public virtual DbSet<EndListTable> EndListTables { get; set; }
        public virtual DbSet<EndTable> EndTables { get; set; }
        public virtual DbSet<OtherDatum> OtherData { get; set; }
        public virtual DbSet<SubListTable> SubListTables { get; set; }
        public virtual DbSet<SubTable> SubTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new DbFirstTableConfiguration());
            modelBuilder.ApplyConfiguration(new EditInfoConfiguration());
            modelBuilder.ApplyConfiguration(new EndListTableConfiguration());
            modelBuilder.ApplyConfiguration(new EndTableConfiguration());
            modelBuilder.ApplyConfiguration(new OtherDatumConfiguration());
            modelBuilder.ApplyConfiguration(new SubListTableConfiguration());
            modelBuilder.ApplyConfiguration(new SubTableConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}