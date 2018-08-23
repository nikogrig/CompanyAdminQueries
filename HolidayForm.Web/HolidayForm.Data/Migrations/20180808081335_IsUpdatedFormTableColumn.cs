using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayForm.Data.Migrations
{
    public partial class IsUpdatedFormTableColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Forms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Forms");
        }
    }
}
