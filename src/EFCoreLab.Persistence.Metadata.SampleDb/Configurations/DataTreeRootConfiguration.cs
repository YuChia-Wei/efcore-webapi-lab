using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Configurations;

public partial class DataTreeRootConfiguration : IEntityTypeConfiguration<DataTreeRoot>
{
    public void Configure(EntityTypeBuilder<DataTreeRoot> entity)
    {
        entity.HasKey(e => e.MainId)
              .HasName("DataTreeRoot_pk")
              .IsClustered(false);

        entity.ToTable("DataTreeRoot");

        entity.Property(e => e.AmountField).HasColumnType("decimal(18, 0)");

        entity.Property(e => e.MainData).HasMaxLength(100);

        entity.HasOne(d => d.Sub)
              .WithMany(p => p.DataTreeRoots)
              .HasForeignKey(d => d.SubId)
              .HasConstraintName("DataTreeRoot_SubTable_SubId_fk");

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<DataTreeRoot> entity);
}