using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayForm.Data.Migrations
{
    public partial class FileFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Forms",
                maxLength: 2097152,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Forms");
        }
    }
}
