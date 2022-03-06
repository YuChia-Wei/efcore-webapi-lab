using LabWebApi.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabWebApi.Repository.Configurations
{
    public partial class EditInfoConfiguration : IEntityTypeConfiguration<EditInfo>
    {
        public void Configure(EntityTypeBuilder<EditInfo> entity)
        {
            entity.HasKey(e => e.EditId)
                  .HasName("EditInfo_pk");

            entity.ToTable("EditInfo");

            entity.HasIndex(e => e.EditId, "EditInfo_EditId_uindex")
                  .IsUnique();

            entity.HasOne(d => d.New)
                  .WithMany(p => p.EditInfoNews)
                  .HasForeignKey(d => d.NewId)
                  .HasConstraintName("EditInfo_OtherData_OtherId_fk_New");

            entity.HasOne(d => d.Old)
                  .WithMany(p => p.EditInfoOlds)
                  .HasForeignKey(d => d.OldId)
                  .HasConstraintName("EditInfo_OtherData_OtherId_fk_Old");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EditInfo> entity);
    }
}