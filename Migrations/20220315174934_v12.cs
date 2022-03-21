using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojSoba",
                table: "Hotel",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojSoba",
                table: "Hotel");
        }
    }
}
