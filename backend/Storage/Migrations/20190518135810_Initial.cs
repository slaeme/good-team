using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GT.Storage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DescriptionPublic = table.Column<string>(nullable: false),
                    DescriptionPrivate = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    MinCountUsers = table.Column<int>(nullable: false),
                    MaxCountUsers = table.Column<int>(nullable: false),
                    CurrentCountUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DeedId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deeds");

            migrationBuilder.DropTable(
                name: "UserDeeds");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
