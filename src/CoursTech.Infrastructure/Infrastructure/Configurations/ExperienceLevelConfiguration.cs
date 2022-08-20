using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class ExperienceLevelConfiguration : IEntityTypeConfiguration<ExperienceLevel>
    {
        public void Configure(EntityTypeBuilder<ExperienceLevel> builder)
        {
            builder.HasData(
                new ExperienceLevel()
                {
                    ExperienceLevelId = 1 ,
                    Name = "Intern / Trainee"
                } ,
                new ExperienceLevel()
                {
                    ExperienceLevelId = 2 ,
                    Name = "Entry Level / Junior"
                } ,
                new ExperienceLevel()
                {
                    ExperienceLevelId = 3 ,
                    Name = "Mid Level"
                },
                new ExperienceLevel()
                {
                    ExperienceLevelId = 4 ,
                    Name = "Senior"
                }
                );
        }
    }
}