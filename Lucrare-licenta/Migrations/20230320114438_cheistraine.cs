using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class cheistraine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JudetID",
                table: "PersoanaJuridica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalitateID",
                table: "PersoanaJuridica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JudetID",
                table: "PersoanaFizica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalitateID",
                table: "PersoanaFizica",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_JudetID",
                table: "PersoanaJuridica",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_LocalitateID",
                table: "PersoanaJuridica",
                column: "LocalitateID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaFizica_JudetID",
                table: "PersoanaFizica",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaFizica_LocalitateID",
                table: "PersoanaFizica",
                column: "LocalitateID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoanaFizica_Judet_JudetID",
                table: "PersoanaFizica",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoanaFizica_Localitate_LocalitateID",
                table: "PersoanaFizica",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoanaJuridica_Judet_JudetID",
                table: "PersoanaJuridica",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoanaJuridica_Localitate_LocalitateID",
                table: "PersoanaJuridica",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersoanaFizica_Judet_JudetID",
                table: "PersoanaFizica");

            migrationBuilder.DropForeignKey(
                name: "FK_PersoanaFizica_Localitate_LocalitateID",
                table: "PersoanaFizica");

            migrationBuilder.DropForeignKey(
                name: "FK_PersoanaJuridica_Judet_JudetID",
                table: "PersoanaJuridica");

            migrationBuilder.DropForeignKey(
                name: "FK_PersoanaJuridica_Localitate_LocalitateID",
                table: "PersoanaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PersoanaJuridica_JudetID",
                table: "PersoanaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PersoanaJuridica_LocalitateID",
                table: "PersoanaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PersoanaFizica_JudetID",
                table: "PersoanaFizica");

            migrationBuilder.DropIndex(
                name: "IX_PersoanaFizica_LocalitateID",
                table: "PersoanaFizica");

            migrationBuilder.DropColumn(
                name: "JudetID",
                table: "PersoanaJuridica");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "PersoanaJuridica");

            migrationBuilder.DropColumn(
                name: "JudetID",
                table: "PersoanaFizica");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "PersoanaFizica");
        }
    }
}
