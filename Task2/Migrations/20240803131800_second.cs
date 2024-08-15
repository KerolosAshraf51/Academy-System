using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_Crs_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_departments_Dept_id",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_id",
                table: "instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Crs_id",
                table: "instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_Crs_id",
                table: "instructors",
                column: "Crs_id",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_departments_Dept_id",
                table: "instructors",
                column: "Dept_id",
                principalTable: "departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_Crs_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_departments_Dept_id",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_id",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Crs_id",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_Crs_id",
                table: "instructors",
                column: "Crs_id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_departments_Dept_id",
                table: "instructors",
                column: "Dept_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
