using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHubApi.Migrations
{
    /// <inheritdoc />
    public partial class studentregistermissingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "students",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "students");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
