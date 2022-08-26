using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaitGate.Migrations
{
    public partial class third2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Documents");

            migrationBuilder.AddColumn<bool>(
                name: "isSent",
                table: "DocumentStates",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSent",
                table: "DocumentStates");

            migrationBuilder.AddColumn<long>(
                name: "Client",
                table: "Documents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
