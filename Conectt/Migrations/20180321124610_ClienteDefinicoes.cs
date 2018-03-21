using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Conectt.Migrations
{
    public partial class ClienteDefinicoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Celular = table.Column<string>(maxLength: 9, nullable: true),
                    CelularDdd = table.Column<string>(maxLength: 2, nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Empresa = table.Column<string>(maxLength: 50, nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 250, nullable: false),
                    TelefoneComercial = table.Column<string>(maxLength: 9, nullable: true),
                    TelefoneComercialDdd = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id",
                table: "Cliente",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
