using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyLab.Infrastructure.Migrations
{
    public partial class AssignmentTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Assignments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Assignments");
        }
    }
}
