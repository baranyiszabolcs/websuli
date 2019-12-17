using Microsoft.EntityFrameworkCore.Migrations;

namespace websuli.Migrations
{
    public partial class ipcim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ipcim",
                table: "Feladatsor",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ipcim",
                table: "Feladatsor");
        }
    }
}
