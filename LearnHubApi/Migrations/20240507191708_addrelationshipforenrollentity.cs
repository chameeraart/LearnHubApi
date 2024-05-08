using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHubApi.Migrations
{
    /// <inheritdoc />
    public partial class addrelationshipforenrollentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrolls_courses_Course_Id",
                table: "enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_enrolls_students_Student_Id",
                table: "enrolls");

            migrationBuilder.RenameColumn(
                name: "Student_Id",
                table: "enrolls",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Course_Id",
                table: "enrolls",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_enrolls_Student_Id",
                table: "enrolls",
                newName: "IX_enrolls_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_enrolls_Course_Id",
                table: "enrolls",
                newName: "IX_enrolls_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_enrolls_courses_CourseId",
                table: "enrolls",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrolls_students_StudentId",
                table: "enrolls",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrolls_courses_CourseId",
                table: "enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_enrolls_students_StudentId",
                table: "enrolls");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "enrolls",
                newName: "Student_Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "enrolls",
                newName: "Course_Id");

            migrationBuilder.RenameIndex(
                name: "IX_enrolls_StudentId",
                table: "enrolls",
                newName: "IX_enrolls_Student_Id");

            migrationBuilder.RenameIndex(
                name: "IX_enrolls_CourseId",
                table: "enrolls",
                newName: "IX_enrolls_Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrolls_courses_Course_Id",
                table: "enrolls",
                column: "Course_Id",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrolls_students_Student_Id",
                table: "enrolls",
                column: "Student_Id",
                principalTable: "students",
                principalColumn: "Id");
        }
    }
}
