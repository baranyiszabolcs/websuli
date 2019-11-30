using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace websuli.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feladatsor",
                columns: table => new
                {
                    FeladatsorID = table.Column<Guid>(nullable: false),
                    sornev = table.Column<string>(nullable: true),
                    gyerek = table.Column<string>(maxLength: 50, nullable: true),
                    feladatTipus = table.Column<string>(nullable: true),
                    eredmenypct = table.Column<int>(nullable: false),
                    feladatszam = table.Column<int>(nullable: false),
                    helyescnt = table.Column<int>(nullable: false),
                    hibascnt = table.Column<int>(nullable: false),
                    kiadasDatum = table.Column<DateTime>(nullable: false),
                    cnt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feladatsor", x => x.FeladatsorID);
                });

            migrationBuilder.CreateTable(
                name: "Feladatok",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeladatsorID = table.Column<Guid>(nullable: true),
                    Helyesvalasz = table.Column<string>(nullable: true),
                    Gyerekvalasz = table.Column<string>(nullable: true),
                    eredmeny = table.Column<int>(nullable: false),
                    ValaszidoSec = table.Column<int>(nullable: false),
                    feladatJson = table.Column<string>(nullable: true),
                    feladatText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feladatok", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feladatok_Feladatsor_FeladatsorID",
                        column: x => x.FeladatsorID,
                        principalTable: "Feladatsor",
                        principalColumn: "FeladatsorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feladatok_FeladatsorID",
                table: "Feladatok",
                column: "FeladatsorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feladatok");

            migrationBuilder.DropTable(
                name: "Feladatsor");
        }
    }
}
