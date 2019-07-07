using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBot.Data.Migrations.Mentee
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Languages",
                table: "Mentees",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Languages",
                table: "Mentees",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
