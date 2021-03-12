using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccess.Migrations
{
    public partial class fixNamingInDepartmentModelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModels_Departments_DepartmentModelId",
                table: "EmployeeModels");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "EmployeeModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentModelId",
                table: "EmployeeModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModels_Departments_DepartmentModelId",
                table: "EmployeeModels",
                column: "DepartmentModelId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModels_Departments_DepartmentModelId",
                table: "EmployeeModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentModelId",
                table: "EmployeeModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "EmployeeModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModels_Departments_DepartmentModelId",
                table: "EmployeeModels",
                column: "DepartmentModelId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
