using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaitGate.Migrations
{
    public partial class signObjectAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SignObject",
                table: "Documents",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignObject",
                table: "Documents");
        }
    }
}
