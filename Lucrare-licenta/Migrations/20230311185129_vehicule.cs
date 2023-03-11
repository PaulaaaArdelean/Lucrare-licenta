using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class vehicule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieVehicul",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaVehicul = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVehicul", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipCombustibil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipulCombustibil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCombustibil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicul",
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
                    table.PrimaryKey("PK_Vehicul", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicul_CategorieVehicul_CategorieVehiculID",
                        column: x => x.CategorieVehiculID,
                        principalTable: "CategorieVehicul",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vehicul_TipCombustibil_TipCombustibilID",
                        column: x => x.TipCombustibilID,
                        principalTable: "TipCombustibil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_CategorieVehiculID",
                table: "Vehicul",
                column: "CategorieVehiculID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_TipCombustibilID",
                table: "Vehicul",
                column: "TipCombustibilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicul");

            migrationBuilder.DropTable(
                name: "CategorieVehicul");

            migrationBuilder.DropTable(
                name: "TipCombustibil");
        }
    }
}
