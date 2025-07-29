﻿using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Configurations;

public partial class EndTableConfiguration : IEntityTypeConfiguration<EndTable>
{
    public void Configure(EntityTypeBuilder<EndTable> entity)
    {
        entity.HasKey(e => e.EndId)
              .HasName("EndTable_pk")
              .IsClustered(false);

        entity.ToTable("EndTable");

        entity.Property(e => e.EndData).HasMaxLength(100);

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<EndTable> entity);
}