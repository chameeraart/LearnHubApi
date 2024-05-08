using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHubApi.Migrations
{
    /// <inheritdoc />
    public partial class enrtollandcoursetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "enrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<int>(type: "int", nullable: true),
                    Course_Id = table.Column<int>(type: "int", nullable: true),
                    Created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enrolls_courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_enrolls_students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrolls_Course_Id",
                table: "enrolls",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_enrolls_Student_Id",
                table: "enrolls",
                column: "Student_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrolls");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "courses");
        }
    }
}
