using Application.DataModels;
using Application.Parameters;
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICourseRepository : IEntityRepository<Course , string>
    {
        Task<CoursesDataModel> GetAll(CourseQueryParameters parameters);
    }
}
