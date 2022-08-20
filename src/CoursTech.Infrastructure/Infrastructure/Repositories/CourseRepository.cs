using Application.Parameters;
using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.EntitiesQueryParameters;
using Infrastructure.Helpers;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext context;

        public CourseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Course> Add(Course course)
        {
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
            return course;
        }

        public async Task Delete(string Id)
        {
            var course = await context.Courses.FindAsync(Id);
            if (course != null)
            {
                context.Courses.Remove(course);
                await context.SaveChangesAsync();
            }
            else
                throw new InvalidOperationException($"no existing course with id = {Id}");
        }

        public List<Course> GetAll<CourseQueryParameters>(CourseQueryParameters parameters)
            where CourseQueryParameters : QueryParameters
        {
            return context.Courses.ToList();
        }

        public async Task<Course> GetById(string Id)
        {
            var course = await context.Courses.FindAsync(Id);
            if (course != null)
                return course;
            else
                throw new InvalidOperationException($"no existing course with id = {Id}");
        }

        public async Task<Course> Update(Course course)
        {
            context.Courses.Update(course);
            await context.SaveChangesAsync();
            return course;
        }
    }
}
