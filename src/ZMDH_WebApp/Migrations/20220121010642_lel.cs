using Microsoft.EntityFrameworkCore.Migrations;

namespace ZMDH_WebApp.Migrations
{
    public partial class lel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pedagoog_TherapyId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TherapyId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    PedagoogId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Pedagoog_TherapyId",
                table: "AspNetUsers",
                column: "Pedagoog_TherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TherapyId",
                table: "AspNetUsers",
                column: "TherapyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Therapies_Pedagoog_TherapyId",
                table: "AspNetUsers",
                column: "Pedagoog_TherapyId",
                principalTable: "Therapies",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Therapies_Pedagoog_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Therapies_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Pedagoog_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pedagoog_TherapyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TherapyId",
                table: "AspNetUsers");
        }
    }
}
