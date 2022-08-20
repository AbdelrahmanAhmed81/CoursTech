using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class EmploymentStatusConfiguration : IEntityTypeConfiguration<EmploymentStatus>
    {
        public void Configure(EntityTypeBuilder<EmploymentStatus> builder)
        {
            builder.HasData(
                new EmploymentStatus()
                {
                    EmploymentStatusId = 1 ,
                    Name = "UnEmployeed"
                } ,
                new EmploymentStatus()
                {
                    EmploymentStatusId = 2 ,
                    Name = "Full-Time"
                },
                new EmploymentStatus()
                {
                    EmploymentStatusId = 3 ,
                    Name = "Part-Time"
                }
                );
        }
    }
}