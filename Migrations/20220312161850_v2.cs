using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojKreveta",
                table: "Soba");

            migrationBuilder.DropColumn(
                name: "TrenutniKapacitet",
                table: "Soba");

            migrationBuilder.AddColumn<string>(
                name: "TipSobe",
                table: "Soba",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipSobe",
                table: "Soba");

            migrationBuilder.AddColumn<int>(
                name: "BrojKreveta",
                table: "Soba",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrenutniKapacitet",
                table: "Soba",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
