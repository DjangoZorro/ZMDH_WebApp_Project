using Microsoft.EntityFrameworkCore.Migrations;

namespace ZMDH_WebApp.Migrations
{
    public partial class lel123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Guardians_GuardianId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SelfHelpGroups_SelfHelpGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Therapies_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Guardians_GuardianId",
                table: "AspNetUsers",
                column: "GuardianId",
                principalTable: "Guardians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SelfHelpGroups_SelfHelpGroupId",
                table: "AspNetUsers",
                column: "SelfHelpGroupId",
                principalTable: "SelfHelpGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Therapies_TherapyId",
                table: "AspNetUsers",
                column: "TherapyId",
                principalTable: "Therapies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Guardians_GuardianId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SelfHelpGroups_SelfHelpGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Therapies_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Guardians_GuardianId",
                table: "AspNetUsers",
                column: "GuardianId",
                principalTable: "Guardians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SelfHelpGroups_SelfHelpGroupId",
                table: "AspNetUsers",
                column: "SelfHelpGroupId",
                principalTable: "SelfHelpGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Therapies_TherapyId",
                table: "AspNetUsers",
                column: "TherapyId",
                principalTable: "Therapies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
