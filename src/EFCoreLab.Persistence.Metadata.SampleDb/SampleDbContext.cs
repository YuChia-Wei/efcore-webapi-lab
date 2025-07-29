using EFCoreLab.Persistence.Metadata.SampleDb.Configurations;
using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLab.Persistence.Metadata.SampleDb;

public partial class SampleDbContext : DbContext
{
    public SampleDbContext()
    {
    }

    public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DataTreeRoot> RootTables { get; set; }
    public virtual DbSet<EndListTable> EndListTables { get; set; }
    public virtual DbSet<EndTable> EndTables { get; set; }
    public virtual DbSet<SubListTable> SubListTables { get; set; }
    public virtual DbSet<SubTable> SubTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.ApplyConfiguration(new DataTreeRootConfiguration());
        modelBuilder.ApplyConfiguration(new EndListTableConfiguration());
        modelBuilder.ApplyConfiguration(new EndTableConfiguration());
        modelBuilder.ApplyConfiguration(new SubListTableConfiguration());
        modelBuilder.ApplyConfiguration(new SubTableConfiguration());
        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}