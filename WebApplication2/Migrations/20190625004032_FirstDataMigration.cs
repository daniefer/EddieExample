using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class FirstDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TestClasses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "TestClasses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql(@"update dbo.TestClasses
                set 
                    -- Assumes Value is some sort of Date string. For example: '2019-01-22 15:22:32.333'
	                Date = CONVERT(date, SUBSTRING(Value, 0, 10)),
	                Time = CONVERT(time, SUBSTRING(Value, 10, LEN(Value)))");

            migrationBuilder.DropColumn(name: "Value", table: "TestClasses");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TestClasses");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "TestClasses");

            // Did not migration down the data migration
        }
    }
}
