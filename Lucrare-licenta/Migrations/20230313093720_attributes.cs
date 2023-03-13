using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtributOptional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtributulOptional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributOptional", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AtributOptionalOferta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfertaID = table.Column<int>(type: "int", nullable: false),
                    AtributOptionalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributOptionalOferta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AtributOptionalOferta_AtributOptional_AtributOptionalID",
                        column: x => x.AtributOptionalID,
                        principalTable: "AtributOptional",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtributOptionalOferta_Oferta_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "Oferta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtributOptionalOferta_AtributOptionalID",
                table: "AtributOptionalOferta",
                column: "AtributOptionalID");

            migrationBuilder.CreateIndex(
                name: "IX_AtributOptionalOferta_OfertaID",
                table: "AtributOptionalOferta",
                column: "OfertaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtributOptionalOferta");

            migrationBuilder.DropTable(
                name: "AtributOptional");
        }
    }
}
