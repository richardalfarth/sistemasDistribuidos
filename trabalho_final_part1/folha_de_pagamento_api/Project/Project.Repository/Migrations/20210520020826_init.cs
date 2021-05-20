using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolhaSalarial",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoDoFuncionario = table.Column<int>(type: "int", nullable: false),
                    SalarioBruto = table.Column<double>(type: "float", nullable: false),
                    SalarioLiquido = table.Column<double>(type: "float", nullable: false),
                    INSS = table.Column<double>(type: "float", nullable: false),
                    IRRF = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolhaSalarial", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FolhaSalarial");
        }
    }
}
