using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.CourseId , e.StudentId });
            //builder.HasData(
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10) , //.net dev 
            //        CourseId = new Guid(10 , 9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0) , //c# 11
            //        Date = new DateTime(2020 , 10 , 9)
            //    } ,
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10) , //.net dev 
            //        CourseId = new Guid(7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9 , 8) , //linq
            //        Date = new DateTime(2020 , 11 , 14)
            //    } ,
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0) ,//flutter dev 
            //        CourseId = new Guid(10 , 9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0) , //c# 11
            //        Date = new DateTime(2019 , 3 , 25)
            //    } ,
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0) ,//flutter dev 
            //        CourseId = new Guid(9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10) , //flutter
            //        Date = new DateTime(2021 , 1 , 2)
            //    } ,
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0) ,//flutter dev 
            //        CourseId = new Guid(6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9 , 8 , 7) , //dart
            //        Date = new DateTime(2019 , 10 , 29)
            //    } ,
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0 , 1) ,//software dev 
            //        CourseId = new Guid(8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9) ,//ef core
            //        Date = new DateTime(2021 , 5 , 21)
            //    } ,
            //    new Enrollment()
            //    {
            //        StudentId = new Guid(2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0 , 1) ,//software dev 
            //        CourseId = new Guid(10 , 9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0) ,//c# 11
            //        Date = new DateTime(2021 , 11 , 22)
            //    } , new Enrollment()
            //    {
            //        StudentId = new Guid(2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0 , 1) ,//software dev 
            //        CourseId = new Guid(7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10 , 9 , 8) , //linq
            //        Date = new DateTime(2022 , 1 , 10)
            //    }
            //    );
        }
    }
}
