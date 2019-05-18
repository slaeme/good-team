using Microsoft.EntityFrameworkCore.Migrations;

namespace GT.Storage.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserDeeds_DeedId",
                table: "UserDeeds",
                column: "DeedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeeds_UserId",
                table: "UserDeeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeeds_Deeds_DeedId",
                table: "UserDeeds",
                column: "DeedId",
                principalTable: "Deeds",
                principalColumn: "DeedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeeds_Users_UserId",
                table: "UserDeeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeeds_Deeds_DeedId",
                table: "UserDeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDeeds_Users_UserId",
                table: "UserDeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserDeeds_DeedId",
                table: "UserDeeds");

            migrationBuilder.DropIndex(
                name: "IX_UserDeeds_UserId",
                table: "UserDeeds");
        }
    }
}
