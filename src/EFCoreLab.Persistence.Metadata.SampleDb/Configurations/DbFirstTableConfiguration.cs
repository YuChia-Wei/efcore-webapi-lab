using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Configurations;

public partial class DbFirstTableConfiguration : IEntityTypeConfiguration<RootTable>
{
    public void Configure(EntityTypeBuilder<RootTable> entity)
    {
        entity.HasKey(e => e.MainId)
              .HasName("DbFirstTable_pk")
              .IsClustered(false);

        entity.ToTable("DbFirstTable");

        entity.Property(e => e.AmountField).HasColumnType("decimal(18, 0)");

        entity.Property(e => e.MainData).HasMaxLength(100);

        entity.HasOne(d => d.Sub)
              .WithMany(p => p.DbFirstTables)
              .HasForeignKey(d => d.SubId)
              .HasConstraintName("DbFirstTable_SubTable_SubId_fk");

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RootTable> entity);
}