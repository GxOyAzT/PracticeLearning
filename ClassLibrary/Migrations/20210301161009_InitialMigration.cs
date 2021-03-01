using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authortbl",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    pseudonyms = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authortbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "booktbl",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    pages = table.Column<int>(type: "integer", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booktbl", x => x.id);
                    table.ForeignKey(
                        name: "FK_booktbl_authortbl_authorid",
                        column: x => x.authorid,
                        principalTable: "authortbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booktbl_authorid",
                table: "booktbl",
                column: "authorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booktbl");

            migrationBuilder.DropTable(
                name: "authortbl");
        }
    }
}
