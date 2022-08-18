using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(s => s.Enrollments).WithOne(e => e.Student).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Student()
                {
                    StudentId = new Guid(0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10) ,
                    FirstName = "Abdelrahman" ,
                    LastName = "Gamal" ,
                    Email = "AbdelrahmanGamal@yahoo.com" ,
                    Bio = ".Net Developer" ,
                    BirthDate = new DateTime(1999 , 12 , 5) ,
                    PhotoName = "abdo.png" ,
                    EmploymentStatusId = 1 ,
                    ExperienceLevelId = 1 ,
                    IndustryId = 1
                } ,
                new Student()
                {
                    StudentId = new Guid(1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 0) ,
                    FirstName = "Mostafa" ,
                    LastName = "Talaat" ,
                    Email = "MostafaTalaat@gmail.com" ,
                    Bio = "Flutter Developer" ,
                    BirthDate = new DateTime(1996 , 5 , 10) ,
                    PhotoName = "tata.jpg" ,
                    EmploymentStatusId = 2 ,
                    ExperienceLevelId = 2 ,
                    IndustryId = 2
                }
                );
        }
    }
}
