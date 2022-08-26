using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaitGate.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Clients",
            //    table: "DocumentStates");

            //migrationBuilder.DropColumn(
            //    name: "Clients",
            //    table: "Documents");

            //migrationBuilder.AddColumn<long>(
            //    name: "Client",
            //    table: "DocumentStates",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);

            //migrationBuilder.AlterColumn<long>(
            //    name: "From",
            //    table: "Documents",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L,
            //    oldClrType: typeof(long),
            //    oldType: "bigint",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "Client",
            //    table: "Documents",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "DocumentStates");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Clients",
                table: "DocumentStates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "From",
                table: "Documents",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Clients",
                table: "Documents",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
