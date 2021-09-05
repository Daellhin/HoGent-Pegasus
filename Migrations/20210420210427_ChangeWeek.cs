using Microsoft.EntityFrameworkCore.Migrations;

namespace Pegasus.Migrations
{
    public partial class ChangeWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasNextWeek",
                table: "Week");

            migrationBuilder.DropColumn(
                name: "HasPreviousWeek",
                table: "Week");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Week",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Week");

            migrationBuilder.AddColumn<bool>(
                name: "HasNextWeek",
                table: "Week",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPreviousWeek",
                table: "Week",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
