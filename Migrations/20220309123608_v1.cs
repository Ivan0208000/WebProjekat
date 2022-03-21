using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(type: "int", nullable: false),
                    TipSobe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojDana = table.Column<int>(type: "int", nullable: false),
                    RoomService = table.Column<bool>(type: "bit", nullable: false),
                    KonacnaCena = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Racun_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(type: "int", nullable: false),
                    BrojKreveta = table.Column<int>(type: "int", nullable: false),
                    TrenutniKapacitet = table.Column<int>(type: "int", nullable: false),
                    BrojDana = table.Column<int>(type: "int", nullable: false),
                    Zauzeta = table.Column<bool>(type: "bit", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Soba_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gost",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LicnaKarta = table.Column<int>(type: "int", nullable: false),
                    SobaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gost", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gost_Soba_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Soba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gost_SobaID",
                table: "Gost",
                column: "SobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_HotelID",
                table: "Racun",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_HotelID",
                table: "Soba",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gost");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
