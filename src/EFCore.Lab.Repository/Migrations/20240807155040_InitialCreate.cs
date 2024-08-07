using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Lab.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EndTable",
                columns: table => new
                {
                    EndId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EndTable_pk", x => x.EndId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "OtherData",
                columns: table => new
                {
                    OtherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OtherData_pk", x => x.OtherId);
                });

            migrationBuilder.CreateTable(
                name: "SubTable",
                columns: table => new
                {
                    SubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EndId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SubTable_pk", x => x.SubId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "SubTable_EndTalbe_EndId_fk",
                        column: x => x.EndId,
                        principalTable: "EndTable",
                        principalColumn: "EndId");
                });

            migrationBuilder.CreateTable(
                name: "EditInfo",
                columns: table => new
                {
                    EditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldId = table.Column<int>(type: "int", nullable: true),
                    NewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EditInfo_pk", x => x.EditId);
                    table.ForeignKey(
                        name: "EditInfo_OtherData_OtherId_fk_New",
                        column: x => x.NewId,
                        principalTable: "OtherData",
                        principalColumn: "OtherId");
                    table.ForeignKey(
                        name: "EditInfo_OtherData_OtherId_fk_Old",
                        column: x => x.OldId,
                        principalTable: "OtherData",
                        principalColumn: "OtherId");
                });

            migrationBuilder.CreateTable(
                name: "DbFirstTable",
                columns: table => new
                {
                    MainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AmountField = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DateTimeField = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DbFirstTable_pk", x => x.MainId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "DbFirstTable_SubTable_SubId_fk",
                        column: x => x.SubId,
                        principalTable: "SubTable",
                        principalColumn: "SubId");
                });

            migrationBuilder.CreateTable(
                name: "SubListTable",
                columns: table => new
                {
                    SubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SubListTable_pk", x => x.SubId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "SubListTable_MainTable_MainId_fk",
                        column: x => x.MainId,
                        principalTable: "DbFirstTable",
                        principalColumn: "MainId");
                });

            migrationBuilder.CreateTable(
                name: "EndListTable",
                columns: table => new
                {
                    EndId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EndListTable_pk", x => x.EndId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "EndListTable_SubTable_SubId_fk",
                        column: x => x.SubId,
                        principalTable: "SubListTable",
                        principalColumn: "SubId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbFirstTable_SubId",
                table: "DbFirstTable",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "EditInfo_EditId_uindex",
                table: "EditInfo",
                column: "EditId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EditInfo_NewId",
                table: "EditInfo",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_EditInfo_OldId",
                table: "EditInfo",
                column: "OldId");

            migrationBuilder.CreateIndex(
                name: "IX_EndListTable_SubId",
                table: "EndListTable",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "OtherData_OtherId_uindex",
                table: "OtherData",
                column: "OtherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubListTable_MainId",
                table: "SubListTable",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTable_EndId",
                table: "SubTable",
                column: "EndId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditInfo");

            migrationBuilder.DropTable(
                name: "EndListTable");

            migrationBuilder.DropTable(
                name: "OtherData");

            migrationBuilder.DropTable(
                name: "SubListTable");

            migrationBuilder.DropTable(
                name: "DbFirstTable");

            migrationBuilder.DropTable(
                name: "SubTable");

            migrationBuilder.DropTable(
                name: "EndTable");
        }
    }
}
