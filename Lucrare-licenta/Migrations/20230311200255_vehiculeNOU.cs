using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class vehiculeNOU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnFabricatie",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "CapacitateCilindrica",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "MasaMaxima",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "NrInmatriculare",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "NrLocuri",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "NumarIdentificare",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "Putere",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "SerieCIV",
                table: "Vehicul");

            migrationBuilder.AddColumn<int>(
                name: "OfertaID",
                table: "Vehicul",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_OfertaID",
                table: "Vehicul",
                column: "OfertaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicul_Oferta_OfertaID",
                table: "Vehicul",
                column: "OfertaID",
                principalTable: "Oferta",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicul_Oferta_OfertaID",
                table: "Vehicul");

            migrationBuilder.DropIndex(
                name: "IX_Vehicul_OfertaID",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "OfertaID",
                table: "Vehicul");

            migrationBuilder.AddColumn<string>(
                name: "AnFabricatie",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CapacitateCilindrica",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MasaMaxima",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NrInmatriculare",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NrLocuri",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumarIdentificare",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Putere",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerieCIV",
                table: "Vehicul",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
