using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BrojDana",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "BrojSobe",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "TipSobe",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "DatumOdjavljivanja",
                table: "Gost");

            migrationBuilder.DropColumn(
                name: "DatumPrijavljivanja",
                table: "Gost");

            migrationBuilder.AddColumn<int>(
                name: "sobaID",
                table: "Racun",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GostuSobi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SobaID = table.Column<int>(type: "int", nullable: true),
                    GostID = table.Column<int>(type: "int", nullable: true),
                    DatumPrijaljivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumOdjavljivanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GostuSobi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GostuSobi_Gost_GostID",
                        column: x => x.GostID,
                        principalTable: "Gost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GostuSobi_Soba_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Soba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racun_sobaID",
                table: "Racun",
                column: "sobaID");

            migrationBuilder.CreateIndex(
                name: "IX_GostuSobi_GostID",
                table: "GostuSobi",
                column: "GostID");

            migrationBuilder.CreateIndex(
                name: "IX_GostuSobi_SobaID",
                table: "GostuSobi",
                column: "SobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Soba_sobaID",
                table: "Racun",
                column: "sobaID",
                principalTable: "Soba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Soba_sobaID",
                table: "Racun");

            migrationBuilder.DropTable(
                name: "GostuSobi");

            migrationBuilder.DropIndex(
                name: "IX_Racun_sobaID",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "sobaID",
                table: "Racun");

            migrationBuilder.AddColumn<int>(
                name: "gostID",
                table: "Soba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojDana",
                table: "Racun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrojSobe",
                table: "Racun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipSobe",
                table: "Racun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumOdjavljivanja",
                table: "Gost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPrijavljivanja",
                table: "Gost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
