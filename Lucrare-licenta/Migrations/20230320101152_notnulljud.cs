using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    public partial class notnulljud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Judet_JudetID",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Localitate_LocalitateID",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Client",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Client",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Judet_JudetID",
                table: "Client",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Localitate_LocalitateID",
                table: "Client",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Judet_JudetID",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Localitate_LocalitateID",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Client",
                type: "int",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Client",
                type: "int",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Judet_JudetID",
                table: "Client",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Localitate_LocalitateID",
                table: "Client",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }
    }
}
