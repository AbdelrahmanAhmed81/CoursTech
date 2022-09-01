using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.HasData(
                new Industry()
                {
                    IndustryId = 1,
                    Name = "Web Development",
                },
                new Industry()
                {
                    IndustryId = 2 ,
                    Name = "Mobile Development" ,
                },
                new Industry()
                {
                    IndustryId = 3 ,
                    Name = "Software Development" ,
                }
                );
        }
    }
}