using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumOdjavljivanja",
                table: "Gost");

            migrationBuilder.DropColumn(
                name: "DatumPrijavljivanja",
                table: "Gost");
        }
    }
}
