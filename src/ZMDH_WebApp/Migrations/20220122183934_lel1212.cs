using Microsoft.EntityFrameworkCore.Migrations;

namespace ZMDH_WebApp.Migrations
{
    public partial class lel1212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Therapies_Pedagoog_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Therapies_Pedagoog_TherapyId",
                table: "AspNetUsers",
                column: "Pedagoog_TherapyId",
                principalTable: "Therapies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Therapies_Pedagoog_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Therapies_Pedagoog_TherapyId",
                table: "AspNetUsers",
                column: "Pedagoog_TherapyId",
                principalTable: "Therapies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
