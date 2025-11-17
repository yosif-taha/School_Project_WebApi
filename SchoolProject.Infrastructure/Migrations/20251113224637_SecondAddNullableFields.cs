using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondAddNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DepartmentId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsructorId",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InsructorId",
                table: "departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsructorId",
                table: "departments",
                column: "InsructorId",
                unique: true,
                filter: "[InsructorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DepartmentId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsructorId",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsructorId",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsructorId",
                table: "departments",
                column: "InsructorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
