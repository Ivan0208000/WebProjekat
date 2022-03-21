using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v116 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomService",
                table: "Racun");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RoomService",
                table: "Racun",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
