using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEM.API.Migrations
{
    public partial class ExtendedUserWithAllowedApps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllowedApps",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedApps",
                table: "Users");
        }
    }
}
