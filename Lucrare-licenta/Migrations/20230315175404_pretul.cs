using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class pretul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pret",
                table: "Oferta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Oferta");
        }
    }
}
