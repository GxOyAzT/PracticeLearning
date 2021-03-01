using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary.Migrations.ManyToManyDb
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorModelTrackModel",
                columns: table => new
                {
                    AuthorModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModelTrackModel", x => new { x.AuthorModelsId, x.TrackModelsId });
                    table.ForeignKey(
                        name: "FK_AuthorModelTrackModel_AuthorModels_AuthorModelsId",
                        column: x => x.AuthorModelsId,
                        principalTable: "AuthorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModelTrackModel_TrackModels_TrackModelsId",
                        column: x => x.TrackModelsId,
                        principalTable: "TrackModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModelTrackModel_TrackModelsId",
                table: "AuthorModelTrackModel",
                column: "TrackModelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModelTrackModel");

            migrationBuilder.DropTable(
                name: "AuthorModels");

            migrationBuilder.DropTable(
                name: "TrackModels");
        }
    }
}
