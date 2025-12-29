using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianTraditionsAndCustoms.Migrations
{
    /// <inheritdoc />
    public partial class CreateTraditionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Traditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CelebrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    TraditionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traditions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traditions_TraditionTypes_TraditionTypeId",
                        column: x => x.TraditionTypeId,
                        principalTable: "TraditionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Traditions_RegionId",
                table: "Traditions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Traditions_TraditionTypeId",
                table: "Traditions",
                column: "TraditionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Traditions");
        }
    }
}
