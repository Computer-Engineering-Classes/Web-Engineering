using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2018_PAPP2.Data.Migrations
{
    public partial class FirstStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interessados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interessados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NomeUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Corpo = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interessados");

            migrationBuilder.DropTable(
                name: "Mensagens");
        }
    }
}
