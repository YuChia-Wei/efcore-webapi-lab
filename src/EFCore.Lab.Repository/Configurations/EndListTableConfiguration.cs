using EFCore.Lab.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Lab.Repository.Configurations;

public partial class EndListTableConfiguration : IEntityTypeConfiguration<EndListTable>
{
    public void Configure(EntityTypeBuilder<EndListTable> entity)
    {
        entity.HasKey(e => e.EndId)
              .HasName("EndListTable_pk")
              .IsClustered(false);

        entity.ToTable("EndListTable");

        entity.Property(e => e.EndData).HasMaxLength(100);

        entity.HasOne(d => d.Sub)
              .WithMany(p => p.EndListTables)
              .HasForeignKey(d => d.SubId)
              .HasConstraintName("EndListTable_SubTable_SubId_fk");

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<EndListTable> entity);
}