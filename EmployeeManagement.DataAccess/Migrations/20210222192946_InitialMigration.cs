using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deparemtnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparemtnt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeModels_Deparemtnt_DepartmentModelId",
                        column: x => x.DepartmentModelId,
                        principalTable: "Deparemtnt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeModels_DepartmentModelId",
                table: "EmployeeModels",
                column: "DepartmentModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeModels");

            migrationBuilder.DropTable(
                name: "Deparemtnt");
        }
    }
}
