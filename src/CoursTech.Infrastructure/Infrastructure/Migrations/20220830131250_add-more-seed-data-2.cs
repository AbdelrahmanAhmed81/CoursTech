using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addmoreseeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000007-0006-0005-0403-0201000a0908"),
                column: "IndustryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("0000000a-0009-0008-0706-050403020100"),
                column: "IndustryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "Name",
                value: "Software Development");

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Bio", "Email", "FirstName", "LastName", "PhoneNumber", "PhotoName" },
                values: new object[] { new Guid("0000000c-000d-000e-0f10-111213140a0b"), "Software Developer at Microsoft", "SaraMichael@gmail.com", "Sara", "Michael", "01211554789", "mona.png" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000008-0007-0006-0504-030201000a09"),
                columns: new[] { "IndustryId", "InstructorId" },
                values: new object[] { 3, new Guid("0000000c-000d-000e-0f10-111213140a0b") });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Date", "Description", "Duration", "ImageName", "IndustryId", "InstructorId", "Title" },
                values: new object[] { new Guid("00000005-0004-0003-0201-000a09080706"), new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core 3, together with Microsoft Visual Studio 2019, includes several features to make your life as a web developer easier and more productive.For example ,Visual Studio offers project templates that you can use to develop your web applications.Visual Studio also supports several development modes ,including using Microsoft Internet Information Services(IIS) directly to test your web applications during development time and using a built -in web server to develop your web applications over FTP.", new TimeSpan(0, 11, 50, 0, 0), "aspcore.png", 1, new Guid("0000000c-000d-000e-0f10-111213140a0b"), "ASP.NET Core 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000005-0004-0003-0201-000a09080706"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("0000000c-000d-000e-0f10-111213140a0b"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000007-0006-0005-0403-0201000a0908"),
                column: "IndustryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000008-0007-0006-0504-030201000a09"),
                columns: new[] { "IndustryId", "InstructorId" },
                values: new object[] { 1, new Guid("0000000a-000b-000c-0d0e-0f1011121314") });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("0000000a-0009-0008-0706-050403020100"),
                column: "IndustryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "Name",
                value: "Networks");

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "IndustryId", "Name" },
                values: new object[] { 4, "DevOps" });
        }
    }
}
