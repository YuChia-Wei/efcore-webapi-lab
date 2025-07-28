using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Configurations;

public partial class OtherDatumConfiguration : IEntityTypeConfiguration<OtherData>
{
    public void Configure(EntityTypeBuilder<OtherData> entity)
    {
        entity.HasKey(e => e.OtherId)
              .HasName("OtherData_pk");

        entity.HasIndex(e => e.OtherId, "OtherData_OtherId_uindex")
              .IsUnique();

        entity.Property(e => e.Data).HasMaxLength(1);

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<OtherData> entity);
}