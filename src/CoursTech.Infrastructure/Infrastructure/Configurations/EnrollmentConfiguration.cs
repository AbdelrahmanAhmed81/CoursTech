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
            builder.HasData(
                new Enrollment()
                {
                    StudentId = new Guid(0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10) ,
                    CourseId = new Guid(10 , 9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0) ,
                    Date = new DateTime(2020 , 10 , 9)
                } ,
                new Enrollment()
                {
                    StudentId = new Guid(1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0) ,
                    CourseId = new Guid(10 , 9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0) ,
                    Date = new DateTime(2019 , 3 , 25)
                } ,
                new Enrollment()
                {
                    StudentId = new Guid(1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0) ,
                    CourseId = new Guid(9 , 8 , 7 , 6 , 5 , 4 , 3 , 2 , 1 , 0 , 10) ,
                    Date = new DateTime(2021 , 1 , 2)
                }
                );
        }
    }
}
