using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBot.Data.Migrations
{
    public partial class reeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxMentees",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxMentees",
                table: "Courses");
        }
    }
}
