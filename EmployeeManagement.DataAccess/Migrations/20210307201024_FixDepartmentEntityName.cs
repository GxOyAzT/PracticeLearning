using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccess.Migrations
{
    public partial class FixDepartmentEntityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModels_Deparemtnt_DepartmentModelId",
                table: "EmployeeModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deparemtnt",
                table: "Deparemtnt");

            migrationBuilder.RenameTable(
                name: "Deparemtnt",
                newName: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModels_Departments_DepartmentModelId",
                table: "EmployeeModels",
                column: "DepartmentModelId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModels_Departments_DepartmentModelId",
                table: "EmployeeModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Deparemtnt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deparemtnt",
                table: "Deparemtnt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModels_Deparemtnt_DepartmentModelId",
                table: "EmployeeModels",
                column: "DepartmentModelId",
                principalTable: "Deparemtnt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
