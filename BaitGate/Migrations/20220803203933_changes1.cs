using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaitGate.Migrations
{
    public partial class changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "isValidReason",
                table: "DocumentStates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isValidReason",
                table: "DocumentStates");
        }
    }
}
