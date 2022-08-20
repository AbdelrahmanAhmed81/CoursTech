using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addCoursePostDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000009-0008-0007-0605-04030201000a"),
                column: "Date",
                value: new DateTime(2016, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("0000000a-0009-0008-0706-050403020100"),
                column: "Date",
                value: new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Courses");
        }
    }
}
