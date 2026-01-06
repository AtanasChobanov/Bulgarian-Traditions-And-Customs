using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianTraditionsAndCustoms.Migrations
{
    /// <inheritdoc />
    public partial class DropRegionsAndTraditionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traditions_Regions_RegionId",
                table: "Traditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Traditions_TraditionTypes_TraditionTypeId",
                table: "Traditions");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "TraditionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Traditions_RegionId",
                table: "Traditions");

            migrationBuilder.DropIndex(
                name: "IX_Traditions_TraditionTypeId",
                table: "Traditions");

            migrationBuilder.RenameColumn(
                name: "TraditionTypeId",
                table: "Traditions",
                newName: "TraditionType");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Traditions",
                newName: "Region");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TraditionType",
                table: "Traditions",
                newName: "TraditionTypeId");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Traditions",
                newName: "RegionId");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraditionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraditionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Traditions_RegionId",
                table: "Traditions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Traditions_TraditionTypeId",
                table: "Traditions",
                column: "TraditionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Traditions_Regions_RegionId",
                table: "Traditions",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traditions_TraditionTypes_TraditionTypeId",
                table: "Traditions",
                column: "TraditionTypeId",
                principalTable: "TraditionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
