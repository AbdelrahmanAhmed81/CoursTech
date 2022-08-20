using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addCourseImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000009-0008-0007-0605-04030201000a"),
                column: "ImageName",
                value: "flutter.png");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("0000000a-0009-0008-0706-050403020100"),
                column: "ImageName",
                value: "csharp11.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Courses");
        }
    }
}
