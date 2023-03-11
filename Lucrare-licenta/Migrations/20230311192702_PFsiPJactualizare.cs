using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class PFsiPJactualizare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipSocietateID",
                table: "PersoanaJuridica",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_TipSocietateID",
                table: "PersoanaJuridica",
                column: "TipSocietateID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoanaJuridica_TipSocietate_TipSocietateID",
                table: "PersoanaJuridica",
                column: "TipSocietateID",
                principalTable: "TipSocietate",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersoanaJuridica_TipSocietate_TipSocietateID",
                table: "PersoanaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PersoanaJuridica_TipSocietateID",
                table: "PersoanaJuridica");

            migrationBuilder.DropColumn(
                name: "TipSocietateID",
                table: "PersoanaJuridica");
        }
    }
}
