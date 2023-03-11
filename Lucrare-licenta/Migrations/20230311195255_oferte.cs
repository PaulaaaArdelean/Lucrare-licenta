using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class oferte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Vehicul",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarIdentificare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrInmatriculare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnFabricatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacitateCilindrica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerieCIV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrLocuri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasaMaxima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Putere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieVehiculID = table.Column<int>(type: "int", nullable: true),
                    TipCombustibilID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oferta_CategorieVehicul_CategorieVehiculID",
                        column: x => x.CategorieVehiculID,
                        principalTable: "CategorieVehicul",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Oferta_TipCombustibil_TipCombustibilID",
                        column: x => x.TipCombustibilID,
                        principalTable: "TipCombustibil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_ClientID",
                table: "Vehicul",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_CategorieVehiculID",
                table: "Oferta",
                column: "CategorieVehiculID");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_TipCombustibilID",
                table: "Oferta",
                column: "TipCombustibilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicul_Client_ClientID",
                table: "Vehicul",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicul_Client_ClientID",
                table: "Vehicul");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropIndex(
                name: "IX_Vehicul_ClientID",
                table: "Vehicul");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Vehicul");
        }
    }
}
