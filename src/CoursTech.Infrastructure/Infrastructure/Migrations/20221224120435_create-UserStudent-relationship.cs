using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class createUserStudentrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("00000006-0005-0004-0302-01000a090807"), new Guid("00000001-0002-0003-0405-060708090a00") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("00000007-0006-0005-0403-0201000a0908"), new Guid("00000000-0001-0002-0304-05060708090a") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("00000007-0006-0005-0403-0201000a0908"), new Guid("00000002-0003-0004-0506-0708090a0001") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("00000008-0007-0006-0504-030201000a09"), new Guid("00000002-0003-0004-0506-0708090a0001") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("00000009-0008-0007-0605-04030201000a"), new Guid("00000001-0002-0003-0405-060708090a00") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000000-0001-0002-0304-05060708090a") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000001-0002-0003-0405-060708090a00") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000002-0003-0004-0506-0708090a0001") });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("00000000-0001-0002-0304-05060708090a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("00000001-0002-0003-0405-060708090a00"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("00000002-0003-0004-0506-0708090a0001"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Bio", "BirthDate", "EmploymentStatusId", "ExperienceLevelId", "FirstName", "IndustryId", "LastName", "PhotoName", "UserId" },
                values: new object[] { new Guid("00000000-0001-0002-0304-05060708090a"), ".Net Developer", new DateTime(1999, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Abdelrahman", 1, "Gamal", "abdo.png", "student1" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Bio", "BirthDate", "EmploymentStatusId", "ExperienceLevelId", "FirstName", "IndustryId", "LastName", "PhotoName", "UserId" },
                values: new object[] { new Guid("00000001-0002-0003-0405-060708090a00"), "Flutter Developer", new DateTime(1996, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Mostafa", 2, "Talaat", "tata.jpg", "student2" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Bio", "BirthDate", "EmploymentStatusId", "ExperienceLevelId", "FirstName", "IndustryId", "LastName", "PhotoName", "UserId" },
                values: new object[] { new Guid("00000002-0003-0004-0506-0708090a0001"), "Software Developer", new DateTime(1996, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "Saeed", 1, "Abdallah", "saeed.png", "student3" });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "Date" },
                values: new object[,]
                {
                    { new Guid("00000006-0005-0004-0302-01000a090807"), new Guid("00000001-0002-0003-0405-060708090a00"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000007-0006-0005-0403-0201000a0908"), new Guid("00000000-0001-0002-0304-05060708090a"), new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000007-0006-0005-0403-0201000a0908"), new Guid("00000002-0003-0004-0506-0708090a0001"), new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000008-0007-0006-0504-030201000a09"), new Guid("00000002-0003-0004-0506-0708090a0001"), new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000009-0008-0007-0605-04030201000a"), new Guid("00000001-0002-0003-0405-060708090a00"), new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000000-0001-0002-0304-05060708090a"), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000001-0002-0003-0405-060708090a00"), new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000002-0003-0004-0506-0708090a0001"), new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
