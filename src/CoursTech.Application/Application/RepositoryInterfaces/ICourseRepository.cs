using Application.Parameters;
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICourseRepository : IEntityRepository<Course , string>
    {
        Task<List<Course>> GetAll(CourseQueryParameters parameters);

    }
}
