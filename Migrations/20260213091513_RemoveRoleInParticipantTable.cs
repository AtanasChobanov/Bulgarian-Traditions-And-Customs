using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianTraditionsAndCustoms.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleInParticipantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Participants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Participants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
