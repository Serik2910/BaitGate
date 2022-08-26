using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaitGate.Migrations
{
    public partial class third1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLDoocument",
                table: "clients");

            migrationBuilder.AddColumn<bool>(
                name: "isSent",
                table: "Documents",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "URLState",
                keyValue: null,
                column: "URLState",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "URLState",
                table: "clients",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "URLDocument",
                table: "clients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSent",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "URLDocument",
                table: "clients");

            migrationBuilder.AlterColumn<string>(
                name: "URLState",
                table: "clients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "URLDoocument",
                table: "clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
