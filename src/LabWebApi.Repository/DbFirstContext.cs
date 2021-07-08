using LabWebApi.Repository.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabWebApi.Repository
{
    public partial class DbFirstContext : DbContext
    {
        public DbFirstContext()
        {
        }

        public DbFirstContext(DbContextOptions<DbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbFirstTable> DbFirstTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFCoreSample;Persist Security Info=False;User ID=SA;Password=<YourStrong@Passw0rd>;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DbFirstTable>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("DbFirstTable_pk")
                    .IsClustered(false);

                entity.ToTable("DbFirstTable", "DbFirstSample");

                entity.Property(e => e.Id).HasComment("?? PK ??");

                entity.Property(e => e.AmountField)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("?????? (?????? decimal)");

                entity.Property(e => e.DateTimeField).HasComment("??????");

                entity.Property(e => e.StringField)
                    .HasMaxLength(1)
                    .HasComment("??????");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
