using Microsoft.EntityFrameworkCore.Migrations;

namespace SEM.API.Migrations
{
    public partial class ExtendedUserWithMinutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WastedMinutes",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkedMinutes",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WastedMinutes",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkedMinutes",
                table: "Users");
        }
    }
}
