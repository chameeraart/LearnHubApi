using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHubApi.Migrations
{
    /// <inheritdoc />
    public partial class adduseridusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentid",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "studentid",
                table: "users");
        }
    }
}
