using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cliente.BancoDeDadosEF.Migrations
{
    public partial class Versao_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cliente");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Id",
                schema: "Cliente",
                table: "Cliente",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "Cliente");
        }
    }
}
