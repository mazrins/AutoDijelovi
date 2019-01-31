using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoDijelovi1.Migrations
{
    public partial class Migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skladiste",
                columns: table => new
                {
                    SkladisteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivSkladista = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladiste", x => x.SkladisteId);
                });

            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivAuta = table.Column<string>(nullable: true),
                    GodinaProizvodnje = table.Column<DateTime>(nullable: false),
                    Dio = table.Column<string>(nullable: true),
                    SkladisteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.AutoID);
                    table.ForeignKey(
                        name: "FK_Auto_Skladiste_SkladisteID",
                        column: x => x.SkladisteID,
                        principalTable: "Skladiste",
                        principalColumn: "SkladisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auto_SkladisteID",
                table: "Auto",
                column: "SkladisteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "Skladiste");
        }
    }
}
