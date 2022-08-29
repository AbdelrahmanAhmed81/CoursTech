using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasMany(c => c.Enrollments).WithOne(e => e.Course).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Course()
                {
                    CourseId = new Guid(10 , 9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0) ,
                    Title = "C# 11" ,
                    Description = "Learn C# Programming (in ten easy steps) [Version 2] is suitable for beginner programmers or anyone with experience in another programming language who needs to learn C# from the ground up. Step-by-step it explains how to write C# code to develop Windows applications using either the free Visual Studio Community Edition or a commercial edition of Microsoft Visual Studio (it even explains how to write C# programs using free tools for OS X). This is the completely revised and updated second version of this course." ,
                    Duration = new TimeSpan(10 , 40 , 0) ,
                    ImageName = "csharp11.png" ,
                    Date = new DateTime(2018 , 7 , 15) ,
                    IndustryId = 1 ,
                    InstructorId = new Guid(10 , 11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20)
                } ,
                new Course()
                {
                    CourseId = new Guid(9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10) ,
                    Title = "Flutter" ,
                    Description = "Join the most comprehensive & bestselling Flutter course and learn how to build amazing iOS and Android apps! You don't need to learn Android/ Java and iOS/ Swift to build real native mobile apps!Flutter - a framework developed by Google - allows you to learn one language(Dart) and build beautiful native mobile apps in no time.Flutter is a SDK providing the tooling to compile Dart code into native code and it also gives you a rich set of pre - built and pre - styled UI elements(so called widgets) which you can use to compose your user interfaces." ,
                    Duration = new TimeSpan(15 , 35 , 0) ,
                    ImageName = "flutter.png" ,
                    Date = new DateTime(2016 , 2 , 27) ,
                    IndustryId = 2 ,
                    InstructorId = new Guid(11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20 , 10)
                } ,
                new Course()
                {
                    CourseId = new Guid(8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9) ,
                    Title = "Entity Framework Core (EF Core)" ,
                    Description = "Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology." ,
                    Duration = new TimeSpan(7 , 15 , 0) ,
                    ImageName = "efcore.png" ,
                    Date = new DateTime(2019 , 11 , 25) ,
                    IndustryId = 1 ,
                    InstructorId = new Guid(10 , 11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20)
                } ,
                new Course()
                {
                    CourseId = new Guid(7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9 , 8) ,
                    Title = "LINQ" ,
                    Description = "Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, events. You write queries against strongly typed collections of objects by using language keywords and familiar operators." ,
                    Duration = new TimeSpan(6 , 45 , 0) ,
                    ImageName = "linq.png" ,
                    Date = new DateTime(2020 , 3 , 3) ,
                    IndustryId = 1 ,
                    InstructorId = new Guid(10 , 11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20)
                } ,
                new Course()
                {
                    CourseId = new Guid(6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9 , 8 , 7) ,
                    Title = "Dart for Beginners" ,
                    Description = "This course will walk you through the general syntax of Dart and has a ton of hands-on coding exercises to drill down the foundations.We will start by helping you set up your dart environment ,followed by setting up Intellij(The IDE that we will use to develop Dart programs).Following that we will go over a simple 'hello world' to verify if your dart installation is a success. Next, I will walk you through fundamental dart concepts such as assignments, variables, keywords, arithmetic operators, user inputs, decision making and loops." ,
                    Duration = new TimeSpan(12 , 30 , 0) ,
                    ImageName = "dart.png" ,
                    Date = new DateTime(2019 , 6 , 20) ,
                    IndustryId = 2 ,
                    InstructorId = new Guid(11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20 , 10)
                }
                );
        }
    }
}
