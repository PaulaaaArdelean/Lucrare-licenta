using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class intcapacitatecilindrica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CapacitateCilindrica",
                table: "Oferta",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CapacitateCilindrica",
                table: "Oferta",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
