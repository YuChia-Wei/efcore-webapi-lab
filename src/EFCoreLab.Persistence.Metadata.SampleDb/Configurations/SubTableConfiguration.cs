using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Configurations;

public partial class SubTableConfiguration : IEntityTypeConfiguration<SubTable>
{
    public void Configure(EntityTypeBuilder<SubTable> entity)
    {
        entity.HasKey(e => e.SubId)
              .HasName("SubTable_pk")
              .IsClustered(false);

        entity.ToTable("SubTable");

        entity.Property(e => e.SubData).HasMaxLength(100);

        entity.HasOne(d => d.End)
              .WithMany(p => p.SubTables)
              .HasForeignKey(d => d.EndId)
              .HasConstraintName("SubTable_EndTalbe_EndId_fk");

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<SubTable> entity);
}