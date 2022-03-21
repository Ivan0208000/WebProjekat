using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class VerzijaV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "Gost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gost_HotelID",
                table: "Gost",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gost_Hotel_HotelID",
                table: "Gost",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gost_Hotel_HotelID",
                table: "Gost");

            migrationBuilder.DropIndex(
                name: "IX_Gost_HotelID",
                table: "Gost");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "Gost");
        }
    }
}
