using Microsoft.EntityFrameworkCore.Migrations;

namespace ZMDH_WebApp.Migrations
{
    public partial class lmao5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConsentOfGuardian",
                table: "Entries",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddressGuardian",
                table: "Entries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianName",
                table: "Entries",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsentOfGuardian",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "EmailAddressGuardian",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "GuardianName",
                table: "Entries");
        }
    }
}
