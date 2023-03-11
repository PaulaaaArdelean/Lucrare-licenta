using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class PFsiPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersoanaFizica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoanaFizica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersoanaFizica_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PersoanaJuridica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoanaJuridica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersoanaJuridica_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaFizica_ClientID",
                table: "PersoanaFizica",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_ClientID",
                table: "PersoanaJuridica",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersoanaFizica");

            migrationBuilder.DropTable(
                name: "PersoanaJuridica");
        }
    }
}
