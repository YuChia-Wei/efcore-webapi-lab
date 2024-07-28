using EFCore.Lab.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Lab.Repository.Configurations;

public partial class SubListTableConfiguration : IEntityTypeConfiguration<SubListTable>
{
    public void Configure(EntityTypeBuilder<SubListTable> entity)
    {
        entity.HasKey(e => e.SubId)
              .HasName("SubListTable_pk")
              .IsClustered(false);

        entity.ToTable("SubListTable");

        entity.Property(e => e.SubData).HasMaxLength(100);

        entity.HasOne(d => d.Main)
              .WithMany(p => p.SubListTables)
              .HasForeignKey(d => d.MainId)
              .HasConstraintName("SubListTable_MainTable_MainId_fk");

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<SubListTable> entity);
}