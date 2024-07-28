using EFCore.Lab.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Lab.Repository.Configurations;

public partial class OtherDatumConfiguration : IEntityTypeConfiguration<OtherDatum>
{
    public void Configure(EntityTypeBuilder<OtherDatum> entity)
    {
        entity.HasKey(e => e.OtherId)
              .HasName("OtherData_pk");

        entity.HasIndex(e => e.OtherId, "OtherData_OtherId_uindex")
              .IsUnique();

        entity.Property(e => e.Data).HasMaxLength(1);

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<OtherDatum> entity);
}