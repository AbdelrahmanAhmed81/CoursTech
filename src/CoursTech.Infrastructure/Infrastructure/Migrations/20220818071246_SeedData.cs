using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmploymentStatuses",
                columns: new[] { "EmploymentStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "UnEmployeed" },
                    { 2, "Full-Time" },
                    { 3, "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "ExperienceLevels",
                columns: new[] { "ExperienceLevelId", "Name" },
                values: new object[,]
                {
                    { 1, "Intern / Trainee" },
                    { 2, "Entry Level / Junior" },
                    { 3, "Mid Level" },
                    { 4, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "IndustryId", "Name" },
                values: new object[,]
                {
                    { 1, "Web Development" },
                    { 2, "Mobile Development" },
                    { 3, "Networks" },
                    { 4, "DevOps" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Bio", "Email", "FirstName", "LastName", "PhoneNumber", "PhotoName" },
                values: new object[,]
                {
                    { new Guid("0000000a-000b-000c-0d0e-0f1011121314"), "Software Engineer at ITI", "MohammedSaeed@gmail.com", "Mohammed", "Saeed", "01154881455", "mohammed.png" },
                    { new Guid("0000000b-000c-000d-0e0f-10111213140a"), "Flutter Developer at Google", "AhmedHesham@gmail.com", "Ahmed", "Hesham", "01022114897", "ahmed.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Duration", "IndustryId", "InstructorId", "Title" },
                values: new object[,]
                {
                    { new Guid("00000009-0008-0007-0605-04030201000a"), "Join the most comprehensive & bestselling Flutter course and learn how to build amazing iOS and Android apps! You don't need to learn Android/ Java and iOS/ Swift to build real native mobile apps!Flutter - a framework developed by Google - allows you to learn one language(Dart) and build beautiful native mobile apps in no time.Flutter is a SDK providing the tooling to compile Dart code into native code and it also gives you a rich set of pre - built and pre - styled UI elements(so called widgets) which you can use to compose your user interfaces.", new TimeSpan(0, 15, 35, 0, 0), 2, new Guid("0000000b-000c-000d-0e0f-10111213140a"), "Flutter" },
                    { new Guid("0000000a-0009-0008-0706-050403020100"), "Learn C# Programming (in ten easy steps) [Version 2] is suitable for beginner programmers or anyone with experience in another programming language who needs to learn C# from the ground up. Step-by-step it explains how to write C# code to develop Windows applications using either the free Visual Studio Community Edition or a commercial edition of Microsoft Visual Studio (it even explains how to write C# programs using free tools for OS X). This is the completely revised and updated second version of this course.", new TimeSpan(0, 10, 40, 0, 0), 1, new Guid("0000000a-000b-000c-0d0e-0f1011121314"), "C# 11" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Bio", "BirthDate", "Email", "EmploymentStatusId", "ExperienceLevelId", "FirstName", "IndustryId", "LastName", "PhotoName" },
                values: new object[,]
                {
                    { new Guid("00000000-0001-0002-0304-05060708090a"), ".Net Developer", new DateTime(1999, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "AbdelrahmanGamal@yahoo.com", 1, 1, "Abdelrahman", 1, "Gamal", "abdo.png" },
                    { new Guid("00000001-0002-0003-0405-060708090a00"), "Flutter Developer", new DateTime(1996, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MostafaTalaat@gmail.com", 2, 2, "Mostafa", 2, "Talaat", "tata.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "Date" },
                values: new object[] { new Guid("00000009-0008-0007-0605-04030201000a"), new Guid("00000001-0002-0003-0405-060708090a00"), new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "Date" },
                values: new object[] { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000000-0001-0002-0304-05060708090a"), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "Date" },
                values: new object[] { new Guid("0000000a-0009-0008-0706-050403020100"), new Guid("00000001-0002-0003-0405-060708090a00"), new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmploymentStatuses",
                keyColumn: "EmploymentStatusId",
                keyValue: 3);

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
                table: "ExperienceLevels",
                keyColumn: "ExperienceLevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExperienceLevels",
                keyColumn: "ExperienceLevelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("00000009-0008-0007-0605-04030201000a"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("0000000a-0009-0008-0706-050403020100"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("00000000-0001-0002-0304-05060708090a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("00000001-0002-0003-0405-060708090a00"));

            migrationBuilder.DeleteData(
                table: "EmploymentStatuses",
                keyColumn: "EmploymentStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmploymentStatuses",
                keyColumn: "EmploymentStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExperienceLevels",
                keyColumn: "ExperienceLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExperienceLevels",
                keyColumn: "ExperienceLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("0000000a-000b-000c-0d0e-0f1011121314"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("0000000b-000c-000d-0e0f-10111213140a"));
        }
    }
}
