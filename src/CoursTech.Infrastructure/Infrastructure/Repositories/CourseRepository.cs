using Application.Parameters;
using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Course>> GetAll(CourseQueryParameters parameters)
        {
            IQueryable<Course> result = context.Courses.AsNoTracking();
            //search
            if (!string.IsNullOrWhiteSpace(parameters.searchText))
            {
                result = result.Where(c => c.Title.Contains(parameters.searchText));
            }
            //filteration
            if (parameters.year != null)
            {
                result = result.Where(c => c.Date.Year == parameters.year);
            }
            if (parameters.industry != null)
            {
                result = result.Where(c => c.IndustryId == parameters.industry);
            }
            //sorting
            result = result.Sort(parameters.orderBy ?? "date" , parameters.asc);

            //pagination

            if (parameters.pageNumber == -1 || parameters.pageCapacity == -1)
            {
                throw new InvalidOperationException("page number and/or page capacity are invalid");
            }

            result = result
                .Skip((parameters.pageNumber - 1) * parameters.pageCapacity)
                .Take(parameters.pageCapacity);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException("this combination of page number and page capacity fetches no data");
            }

            //expanding
            if (parameters.expand != null && parameters.expand.Length != 0)
            {
                result = result.Expand(parameters.expand);
            }

            return await result.ToListAsync();
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
