using Microsoft.EntityFrameworkCore.Migrations;

namespace GT.Storage.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserDeeds",
                newName: "UserDeedId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Deeds",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Deeds",
                newName: "DeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Deeds_UserId",
                table: "Deeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deeds_Users_UserId",
                table: "Deeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deeds_Users_UserId",
                table: "Deeds");

            migrationBuilder.DropIndex(
                name: "IX_Deeds_UserId",
                table: "Deeds");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserDeedId",
                table: "UserDeeds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Deeds",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DeedId",
                table: "Deeds",
                newName: "Id");
        }
    }
}
