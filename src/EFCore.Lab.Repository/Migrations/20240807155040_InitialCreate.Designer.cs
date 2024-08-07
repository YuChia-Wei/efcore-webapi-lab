﻿// <auto-generated />
using System;
using EFCore.Lab.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Lab.Repository.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20240807155040_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.DbFirstTable", b =>
                {
                    b.Property<int>("MainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MainId"));

                    b.Property<decimal?>("AmountField")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("DateTimeField")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainData")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SubId")
                        .HasColumnType("int");

                    b.HasKey("MainId")
                        .HasName("DbFirstTable_pk");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MainId"), false);

                    b.HasIndex("SubId");

                    b.ToTable("DbFirstTable", (string)null);
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.EditInfo", b =>
                {
                    b.Property<int>("EditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EditId"));

                    b.Property<int?>("NewId")
                        .HasColumnType("int");

                    b.Property<int?>("OldId")
                        .HasColumnType("int");

                    b.HasKey("EditId")
                        .HasName("EditInfo_pk");

                    b.HasIndex("NewId");

                    b.HasIndex("OldId");

                    b.HasIndex(new[] { "EditId" }, "EditInfo_EditId_uindex")
                        .IsUnique();

                    b.ToTable("EditInfo", (string)null);
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.EndListTable", b =>
                {
                    b.Property<int>("EndId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EndId"));

                    b.Property<string>("EndData")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SubId")
                        .HasColumnType("int");

                    b.HasKey("EndId")
                        .HasName("EndListTable_pk");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("EndId"), false);

                    b.HasIndex("SubId");

                    b.ToTable("EndListTable", (string)null);
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.EndTable", b =>
                {
                    b.Property<int>("EndId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EndId"));

                    b.Property<string>("EndData")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EndId")
                        .HasName("EndTable_pk");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("EndId"), false);

                    b.ToTable("EndTable", (string)null);
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.OtherDatum", b =>
                {
                    b.Property<int>("OtherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OtherId"));

                    b.Property<string>("Data")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("OtherId")
                        .HasName("OtherData_pk");

                    b.HasIndex(new[] { "OtherId" }, "OtherData_OtherId_uindex")
                        .IsUnique();

                    b.ToTable("OtherData");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.SubListTable", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubId"));

                    b.Property<int?>("MainId")
                        .HasColumnType("int");

                    b.Property<string>("SubData")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubId")
                        .HasName("SubListTable_pk");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("SubId"), false);

                    b.HasIndex("MainId");

                    b.ToTable("SubListTable", (string)null);
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.SubTable", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubId"));

                    b.Property<int?>("EndId")
                        .HasColumnType("int");

                    b.Property<string>("SubData")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubId")
                        .HasName("SubTable_pk");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("SubId"), false);

                    b.HasIndex("EndId");

                    b.ToTable("SubTable", (string)null);
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.DbFirstTable", b =>
                {
                    b.HasOne("EFCore.Lab.Repository.Entities.SubTable", "Sub")
                        .WithMany("DbFirstTables")
                        .HasForeignKey("SubId")
                        .HasConstraintName("DbFirstTable_SubTable_SubId_fk");

                    b.Navigation("Sub");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.EditInfo", b =>
                {
                    b.HasOne("EFCore.Lab.Repository.Entities.OtherDatum", "New")
                        .WithMany("EditInfoNews")
                        .HasForeignKey("NewId")
                        .HasConstraintName("EditInfo_OtherData_OtherId_fk_New");

                    b.HasOne("EFCore.Lab.Repository.Entities.OtherDatum", "Old")
                        .WithMany("EditInfoOlds")
                        .HasForeignKey("OldId")
                        .HasConstraintName("EditInfo_OtherData_OtherId_fk_Old");

                    b.Navigation("New");

                    b.Navigation("Old");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.EndListTable", b =>
                {
                    b.HasOne("EFCore.Lab.Repository.Entities.SubListTable", "Sub")
                        .WithMany("EndListTables")
                        .HasForeignKey("SubId")
                        .HasConstraintName("EndListTable_SubTable_SubId_fk");

                    b.Navigation("Sub");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.SubListTable", b =>
                {
                    b.HasOne("EFCore.Lab.Repository.Entities.DbFirstTable", "Main")
                        .WithMany("SubListTables")
                        .HasForeignKey("MainId")
                        .HasConstraintName("SubListTable_MainTable_MainId_fk");

                    b.Navigation("Main");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.SubTable", b =>
                {
                    b.HasOne("EFCore.Lab.Repository.Entities.EndTable", "End")
                        .WithMany("SubTables")
                        .HasForeignKey("EndId")
                        .HasConstraintName("SubTable_EndTalbe_EndId_fk");

                    b.Navigation("End");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.DbFirstTable", b =>
                {
                    b.Navigation("SubListTables");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.EndTable", b =>
                {
                    b.Navigation("SubTables");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.OtherDatum", b =>
                {
                    b.Navigation("EditInfoNews");

                    b.Navigation("EditInfoOlds");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.SubListTable", b =>
                {
                    b.Navigation("EndListTables");
                });

            modelBuilder.Entity("EFCore.Lab.Repository.Entities.SubTable", b =>
                {
                    b.Navigation("DbFirstTables");
                });
#pragma warning restore 612, 618
        }
    }
}