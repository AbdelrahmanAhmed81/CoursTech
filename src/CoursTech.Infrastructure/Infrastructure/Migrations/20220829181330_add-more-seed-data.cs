using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addmoreseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Date", "Description", "Duration", "ImageName", "IndustryId", "InstructorId", "Title" },
                values: new object[,]
                {
                    { new Guid("00000006-0005-0004-0302-01000a090807"), new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This course will walk you through the general syntax of Dart and has a ton of hands-on coding exercises to drill down the foundations.We will start by helping you set up your dart environment ,followed by setting up Intellij(The IDE that we will use to develop Dart programs).Following that we will go over a simple 'hello world' to verify if your dart installation is a success. Next, I will walk you through fundamental dart concepts such as assignments, variables, keywords, arithmetic operators, user inputs, decision making and loops.", new TimeSpan(0, 12, 30, 0, 0), "dart.png", 2, new Guid("0000000b-000c-000d-0e0f-10111213140a"), "Dart for Beginners" },
                    { new Guid("00000007-0006-0005-0403-0201000a0908"), new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, events. You write queries against strongly typed collections of objects by using language keywords and familiar operators.", new TimeSpan(0, 6, 45, 0, 0), "linq.png", 1, new Guid("0000000a-000b-000c-0d0e-0f1011121314"), "LINQ" },
                    { new Guid("00000008-0007-0006-0504-030201000a09"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.", new TimeSpan(0, 7, 15, 0, 0), "efcore.png", 1, new Guid("0000000a-000b-000c-0d0e-0f1011121314"), "Entity Framework Core (EF Core)" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Bio", "BirthDate", "Email", "EmploymentStatusId", "ExperienceLevelId", "FirstName", "IndustryId", "LastName", "PhotoName" },
                values: new object[] { new Guid("00000002-0003-0004-0506-0708090a0001"), "Software Developer", new DateTime(1996, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SaeedAbdallah@gmail.com", 2, 3, "Saeed", 1, "Abdallah", "saeed.png" });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "Date" },
                values: new object[,]
                {
                    { new Guid("00000006-0005-0004-0302-01000a090807"), new Guid("00000001-0002-0003-0405-060708090a00"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000007-0006-0005-0403-0201000a0908"), new Guid("00000000-0001-0002-0304-05060708090a"), new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000007-0006-0005-0403-0201000a0908"), new Guid("00000002-0003-0004-0506-0708090a0001"), new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000008-0007-0006-0504-030201000a09"), new Guid("00000002-0003-0004-0506-0708090a0001"), new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000002-0003-0004-0506-0708090a0001"), new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000002-0003-0004-0506-0708090a0001") });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000006-0005-0004-0302-01000a090807"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000007-0006-0005-0403-0201000a0908"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000008-0007-0006-0504-030201000a09"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("00000002-0003-0004-0506-0708090a0001"));
        }
    }
}
