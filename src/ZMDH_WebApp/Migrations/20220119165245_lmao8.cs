using Microsoft.EntityFrameworkCore.Migrations;

namespace ZMDH_WebApp.Migrations
{
    public partial class lmao8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsentOfGuardian",
                table: "Entries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConsentOfGuardian",
                table: "Entries",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
