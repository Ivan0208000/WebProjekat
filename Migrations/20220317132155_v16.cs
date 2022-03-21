using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumOdjavljivanja",
                table: "GostuSobi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatumOdjavljivanja",
                table: "GostuSobi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
