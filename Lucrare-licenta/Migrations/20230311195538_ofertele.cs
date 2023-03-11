using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class ofertele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicul_Client_ClientID",
                table: "Vehicul");

            migrationBuilder.DropIndex(
                name: "IX_Vehicul_ClientID",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Vehicul");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Oferta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ClientID",
                table: "Oferta",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_Client_ClientID",
                table: "Oferta",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_Client_ClientID",
                table: "Oferta");

            migrationBuilder.DropIndex(
                name: "IX_Oferta_ClientID",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Oferta");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Vehicul",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_ClientID",
                table: "Vehicul",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicul_Client_ClientID",
                table: "Vehicul",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }
    }
}
