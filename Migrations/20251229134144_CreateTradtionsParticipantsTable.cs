using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianTraditionsAndCustoms.Migrations
{
    /// <inheritdoc />
    public partial class CreateTradtionsParticipantsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraditionsParticipants",
                columns: table => new
                {
                    TraditionId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    ParticipantRole = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraditionsParticipants", x => new { x.TraditionId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_TraditionsParticipants_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraditionsParticipants_Traditions_TraditionId",
                        column: x => x.TraditionId,
                        principalTable: "Traditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraditionsParticipants_ParticipantId",
                table: "TraditionsParticipants",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraditionsParticipants");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
