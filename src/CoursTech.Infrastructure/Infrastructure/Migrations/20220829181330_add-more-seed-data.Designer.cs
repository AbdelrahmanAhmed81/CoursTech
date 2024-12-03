﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220829181330_add-more-seed-data")]
    partial class addmoreseeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IndustryId")
                        .HasColumnType("int");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("0000000a-0009-0008-0706-050403020100"),
                            Date = new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Learn C# Programming (in ten easy steps) [Version 2] is suitable for beginner programmers or anyone with experience in another programming language who needs to learn C# from the ground up. Step-by-step it explains how to write C# code to develop Windows applications using either the free Visual Studio Community Edition or a commercial edition of Microsoft Visual Studio (it even explains how to write C# programs using free tools for OS X). This is the completely revised and updated second version of this course.",
                            Duration = new TimeSpan(0, 10, 40, 0, 0),
                            ImageName = "csharp11.png",
                            IndustryId = 1,
                            InstructorId = new Guid("0000000a-000b-000c-0d0e-0f1011121314"),
                            Title = "C# 11"
                        },
                        new
                        {
                            CourseId = new Guid("00000009-0008-0007-0605-04030201000a"),
                            Date = new DateTime(2016, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Join the most comprehensive & bestselling Flutter course and learn how to build amazing iOS and Android apps! You don't need to learn Android/ Java and iOS/ Swift to build real native mobile apps!Flutter - a framework developed by Google - allows you to learn one language(Dart) and build beautiful native mobile apps in no time.Flutter is a SDK providing the tooling to compile Dart code into native code and it also gives you a rich set of pre - built and pre - styled UI elements(so called widgets) which you can use to compose your user interfaces.",
                            Duration = new TimeSpan(0, 15, 35, 0, 0),
                            ImageName = "flutter.png",
                            IndustryId = 2,
                            InstructorId = new Guid("0000000b-000c-000d-0e0f-10111213140a"),
                            Title = "Flutter"
                        },
                        new
                        {
                            CourseId = new Guid("00000008-0007-0006-0504-030201000a09"),
                            Date = new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.",
                            Duration = new TimeSpan(0, 7, 15, 0, 0),
                            ImageName = "efcore.png",
                            IndustryId = 1,
                            InstructorId = new Guid("0000000a-000b-000c-0d0e-0f1011121314"),
                            Title = "Entity Framework Core (EF Core)"
                        },
                        new
                        {
                            CourseId = new Guid("00000007-0006-0005-0403-0201000a0908"),
                            Date = new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, events. You write queries against strongly typed collections of objects by using language keywords and familiar operators.",
                            Duration = new TimeSpan(0, 6, 45, 0, 0),
                            ImageName = "linq.png",
                            IndustryId = 1,
                            InstructorId = new Guid("0000000a-000b-000c-0d0e-0f1011121314"),
                            Title = "LINQ"
                        },
                        new
                        {
                            CourseId = new Guid("00000006-0005-0004-0302-01000a090807"),
                            Date = new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This course will walk you through the general syntax of Dart and has a ton of hands-on coding exercises to drill down the foundations.We will start by helping you set up your dart environment ,followed by setting up Intellij(The IDE that we will use to develop Dart programs).Following that we will go over a simple 'hello world' to verify if your dart installation is a success. Next, I will walk you through fundamental dart concepts such as assignments, variables, keywords, arithmetic operators, user inputs, decision making and loops.",
                            Duration = new TimeSpan(0, 12, 30, 0, 0),
                            ImageName = "dart.png",
                            IndustryId = 2,
                            InstructorId = new Guid("0000000b-000c-000d-0e0f-10111213140a"),
                            Title = "Dart for Beginners"
                        });
                });

            modelBuilder.Entity("Domain.Entities.EmploymentStatus", b =>
                {
                    b.Property<int>("EmploymentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmploymentStatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmploymentStatusId");

                    b.ToTable("EmploymentStatuses");

                    b.HasData(
                        new
                        {
                            EmploymentStatusId = 1,
                            Name = "UnEmployeed"
                        },
                        new
                        {
                            EmploymentStatusId = 2,
                            Name = "Full-Time"
                        },
                        new
                        {
                            EmploymentStatusId = 3,
                            Name = "Part-Time"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("0000000a-0009-0008-0706-050403020100"),
                            StudentId = new Guid("00000000-0001-0002-0304-05060708090a"),
                            Date = new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("00000007-0006-0005-0403-0201000a0908"),
                            StudentId = new Guid("00000000-0001-0002-0304-05060708090a"),
                            Date = new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("0000000a-0009-0008-0706-050403020100"),
                            StudentId = new Guid("00000001-0002-0003-0405-060708090a00"),
                            Date = new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("00000009-0008-0007-0605-04030201000a"),
                            StudentId = new Guid("00000001-0002-0003-0405-060708090a00"),
                            Date = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("00000006-0005-0004-0302-01000a090807"),
                            StudentId = new Guid("00000001-0002-0003-0405-060708090a00"),
                            Date = new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("00000008-0007-0006-0504-030201000a09"),
                            StudentId = new Guid("00000002-0003-0004-0506-0708090a0001"),
                            Date = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("0000000a-0009-0008-0706-050403020100"),
                            StudentId = new Guid("00000002-0003-0004-0506-0708090a0001"),
                            Date = new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = new Guid("00000007-0006-0005-0403-0201000a0908"),
                            StudentId = new Guid("00000002-0003-0004-0506-0708090a0001"),
                            Date = new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.ExperienceLevel", b =>
                {
                    b.Property<int>("ExperienceLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceLevelId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienceLevelId");

                    b.ToTable("ExperienceLevels");

                    b.HasData(
                        new
                        {
                            ExperienceLevelId = 1,
                            Name = "Intern / Trainee"
                        },
                        new
                        {
                            ExperienceLevelId = 2,
                            Name = "Entry Level / Junior"
                        },
                        new
                        {
                            ExperienceLevelId = 3,
                            Name = "Mid Level"
                        },
                        new
                        {
                            ExperienceLevelId = 4,
                            Name = "Senior"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Industry", b =>
                {
                    b.Property<int>("IndustryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndustryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IndustryId");

                    b.ToTable("Industries");

                    b.HasData(
                        new
                        {
                            IndustryId = 1,
                            Name = "Web Development"
                        },
                        new
                        {
                            IndustryId = 2,
                            Name = "Mobile Development"
                        },
                        new
                        {
                            IndustryId = 3,
                            Name = "Networks"
                        },
                        new
                        {
                            IndustryId = 4,
                            Name = "DevOps"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Instructor", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            InstructorId = new Guid("0000000a-000b-000c-0d0e-0f1011121314"),
                            Bio = "Software Engineer at ITI",
                            Email = "MohammedSaeed@gmail.com",
                            FirstName = "Mohammed",
                            LastName = "Saeed",
                            PhoneNumber = "01154881455",
                            PhotoName = "mohammed.png"
                        },
                        new
                        {
                            InstructorId = new Guid("0000000b-000c-000d-0e0f-10111213140a"),
                            Bio = "Flutter Developer at Google",
                            Email = "AhmedHesham@gmail.com",
                            FirstName = "Ahmed",
                            LastName = "Hesham",
                            PhoneNumber = "01022114897",
                            PhotoName = "ahmed.jpg"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmploymentStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("ExperienceLevelId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IndustryId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("EmploymentStatusId");

                    b.HasIndex("ExperienceLevelId");

                    b.HasIndex("IndustryId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("00000000-0001-0002-0304-05060708090a"),
                            Bio = ".Net Developer",
                            BirthDate = new DateTime(1999, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "AbdelrahmanGamal@yahoo.com",
                            EmploymentStatusId = 1,
                            ExperienceLevelId = 1,
                            FirstName = "Abdelrahman",
                            IndustryId = 1,
                            LastName = "Gamal",
                            PhotoName = "abdo.png"
                        },
                        new
                        {
                            StudentId = new Guid("00000001-0002-0003-0405-060708090a00"),
                            Bio = "Flutter Developer",
                            BirthDate = new DateTime(1996, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "MostafaTalaat@gmail.com",
                            EmploymentStatusId = 2,
                            ExperienceLevelId = 2,
                            FirstName = "Mostafa",
                            IndustryId = 2,
                            LastName = "Talaat",
                            PhotoName = "tata.jpg"
                        },
                        new
                        {
                            StudentId = new Guid("00000002-0003-0004-0506-0708090a0001"),
                            Bio = "Software Developer",
                            BirthDate = new DateTime(1996, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "SaeedAbdallah@gmail.com",
                            EmploymentStatusId = 2,
                            ExperienceLevelId = 3,
                            FirstName = "Saeed",
                            IndustryId = 1,
                            LastName = "Abdallah",
                            PhotoName = "saeed.png"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.HasOne("Domain.Entities.Industry", "Industry")
                        .WithMany("Courses")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Industry");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Domain.Entities.Enrollment", b =>
                {
                    b.HasOne("Domain.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.HasOne("Domain.Entities.EmploymentStatus", "EmploymentStatus")
                        .WithMany("Students")
                        .HasForeignKey("EmploymentStatusId");

                    b.HasOne("Domain.Entities.ExperienceLevel", "ExperienceLevel")
                        .WithMany("Students")
                        .HasForeignKey("ExperienceLevelId");

                    b.HasOne("Domain.Entities.Industry", "Industry")
                        .WithMany("Students")
                        .HasForeignKey("IndustryId");

                    b.Navigation("EmploymentStatus");

                    b.Navigation("ExperienceLevel");

                    b.Navigation("Industry");
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Domain.Entities.EmploymentStatus", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Entities.ExperienceLevel", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Entities.Industry", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Entities.Instructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
