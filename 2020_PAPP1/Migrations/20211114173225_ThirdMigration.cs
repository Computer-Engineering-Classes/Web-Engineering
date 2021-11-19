using Microsoft.EntityFrameworkCore.Migrations;

namespace _2020_PAPP1.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Utilizador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Utilizador",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
