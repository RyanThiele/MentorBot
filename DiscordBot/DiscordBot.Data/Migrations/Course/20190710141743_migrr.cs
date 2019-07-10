using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBot.Data.Migrations
{
    public partial class migrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
