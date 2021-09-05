using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pegasus.Migrations
{
    public partial class RemovedUnusedPropertiesFromWeekTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfGeneration",
                table: "WeekTemplate");

            migrationBuilder.DropColumn(
                name: "TimeOfGeneration",
                table: "WeekTemplate");

            migrationBuilder.DropColumn(
                name: "WeeksInAdvance",
                table: "WeekTemplate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfGeneration",
                table: "WeekTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfGeneration",
                table: "WeekTemplate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WeeksInAdvance",
                table: "WeekTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
