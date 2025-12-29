using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianTraditionsAndCustoms.Migrations
{
    /// <inheritdoc />
    public partial class CreateTradtionsHolidaysTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CelebrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayTradition",
                columns: table => new
                {
                    HolidaysId = table.Column<int>(type: "int", nullable: false),
                    TraditionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayTradition", x => new { x.HolidaysId, x.TraditionsId });
                    table.ForeignKey(
                        name: "FK_HolidayTradition_Holidays_HolidaysId",
                        column: x => x.HolidaysId,
                        principalTable: "Holidays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayTradition_Traditions_TraditionsId",
                        column: x => x.TraditionsId,
                        principalTable: "Traditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayTradition_TraditionsId",
                table: "HolidayTradition",
                column: "TraditionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayTradition");

            migrationBuilder.DropTable(
                name: "Holidays");
        }
    }
}
