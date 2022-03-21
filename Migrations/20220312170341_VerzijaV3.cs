using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class VerzijaV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gost_Soba_SobaID",
                table: "Gost");

            migrationBuilder.DropIndex(
                name: "IX_Gost_SobaID",
                table: "Gost");

            migrationBuilder.DropColumn(
                name: "SobaID",
                table: "Gost");

            migrationBuilder.AddColumn<int>(
                name: "gostID",
                table: "Soba",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soba_gostID",
                table: "Soba",
                column: "gostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Soba_Gost_gostID",
                table: "Soba",
                column: "gostID",
                principalTable: "Gost",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soba_Gost_gostID",
                table: "Soba");

            migrationBuilder.DropIndex(
                name: "IX_Soba_gostID",
                table: "Soba");

            migrationBuilder.DropColumn(
                name: "gostID",
                table: "Soba");

            migrationBuilder.AddColumn<int>(
                name: "SobaID",
                table: "Gost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gost_SobaID",
                table: "Gost",
                column: "SobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gost_Soba_SobaID",
                table: "Gost",
                column: "SobaID",
                principalTable: "Soba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
