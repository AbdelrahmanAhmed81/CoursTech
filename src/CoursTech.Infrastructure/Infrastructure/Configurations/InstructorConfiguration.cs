using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
                new Instructor()
                {
                    InstructorId = new Guid(10 , 11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20) ,
                    FirstName = "Mohammed" ,
                    LastName = "Saeed" ,
                    Email = "MohammedSaeed@gmail.com" ,
                    Bio = "Software Engineer at ITI" ,
                    PhotoName = "mohammed.png" ,
                    PhoneNumber = "01154881455"
                } ,
                new Instructor()
                {
                    InstructorId = new Guid(11 , 12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20 , 10) ,
                    FirstName = "Ahmed" ,
                    LastName = "Hesham" ,
                    Email = "AhmedHesham@gmail.com" ,
                    Bio = "Flutter Developer at Google" ,
                    PhotoName = "ahmed.jpg" ,
                    PhoneNumber = "01022114897"
                } ,
                new Instructor()
                {
                    InstructorId = new Guid(12 , 13 , 14 , 15 , 16 , 17 , 18 , 19 , 20 , 10 , 11) ,
                    FirstName = "Sara" ,
                    LastName = "Michael" ,
                    Email = "SaraMichael@gmail.com" ,
                    Bio = "Software Developer at Microsoft" ,
                    PhotoName = "mona.png" ,
                    PhoneNumber = "01211554789"
                }
                );
        }
    }
}
