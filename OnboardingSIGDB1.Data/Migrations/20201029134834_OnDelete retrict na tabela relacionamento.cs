using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSIGDB1.Data.Migrations
{
    public partial class OnDeleteretrictnatabelarelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosCargos_Cargos_CargoId",
                table: "FuncionariosCargos");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosCargos_Cargos_CargoId",
                table: "FuncionariosCargos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosCargos_Cargos_CargoId",
                table: "FuncionariosCargos");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosCargos_Cargos_CargoId",
                table: "FuncionariosCargos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
