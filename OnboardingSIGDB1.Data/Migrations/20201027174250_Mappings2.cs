using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSIGDB1.Data.Migrations
{
    public partial class Mappings2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cargos_CargoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Funcionarios");

            migrationBuilder.CreateTable(
                name: "FuncionariosCargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    DataVinculo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosCargos", x => new { x.CargoId, x.FuncionarioId });
                    table.ForeignKey(
                        name: "FK_FuncionariosCargos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosCargos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosCargos_FuncionarioId",
                table: "FuncionariosCargos",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionariosCargos");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cargos_CargoId",
                table: "Funcionarios",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
