using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyLab.Infrastructure.Migrations
{
    public partial class AssignmentStartedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateStarted",
                table: "StudentAssignments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateStarted",
                table: "StudentAssignments");
        }
    }
}
