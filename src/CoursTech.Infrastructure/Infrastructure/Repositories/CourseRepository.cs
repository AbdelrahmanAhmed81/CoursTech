using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

using Application.DataModels;
using Application.Parameters;
using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext context;
        private readonly IHostingEnvironment hostEnvironment;
        public CourseRepository(AppDbContext context , IHostingEnvironment hostEnvironment)
        {
            this.context = context;
            this.hostEnvironment = hostEnvironment;
        }
        public async Task Add(CourseDataModel courseData)
        {
            var fileName = $"{Guid.NewGuid()}-{courseData.Image.FileName}";
            var course = new Course()
            {
                Title = courseData.Title ,
                Description = courseData.Description ,
                Date = courseData.Date ,
                Duration = courseData.Duration ,
                IndustryId = courseData.Industry ,
                InstructorId = courseData.Instructor ,
                ImageName = fileName
            };

            await context.Courses.AddAsync(course);
            int status = await context.SaveChangesAsync();
            if (status == 1)
            {
                await AddCourseImage(courseData.Image , fileName);
            }
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

        public async Task<CoursesDataModel> GetAll(CourseQueryParameters parameters)
        {
            IQueryable<Course> result = context.Courses.AsNoTracking();
            int coursesCount = 0;
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
            coursesCount = result.Count();

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

            //if (coursesCount == 0)
            //{
            //    throw new InvalidOperationException("this combination of page number and page capacity fetches no data");
            //}

            //expanding
            if (parameters.expand != null && parameters.expand.Length != 0)
            {
                result = result.Expand(parameters.expand);
            }

            return new CoursesDataModel() { Courses = await result.ToListAsync() , CoursesCount = coursesCount };
        }

        public async Task<Course> GetById(string Id , string[] expand)
        {
            IQueryable<Course> courses = context.Courses;
            if (expand != null && expand.Length != 0)
            {
                courses = courses.Expand(expand);
            }
            var course = await courses.FirstOrDefaultAsync(c => c.CourseId.ToString() == Id);
            if (course != null)
                return course;
            else
                throw new InvalidOperationException($"no existing course with id = {Id}");
        }

        public async Task Update(CourseDataModel courseData)
        {
            if (courseData.Id != null)
            {
                var oldCourse = context.Courses.Find(courseData.Id.Value);
                if (oldCourse != null)
                {
                    context.Courses.Attach(oldCourse);
                    oldCourse.Title = courseData.Title;
                    oldCourse.Description = courseData.Description;
                    oldCourse.Duration = courseData.Duration;
                    oldCourse.Date = courseData.Date;
                    oldCourse.InstructorId = courseData.Instructor;
                    oldCourse.IndustryId = courseData.Industry;

                    if (courseData.Image != null)
                    {
                        await DeleteCourseImage(oldCourse.ImageName);
                        var fileName = $"{Guid.NewGuid()}-{courseData.Image.FileName}";
                        oldCourse.ImageName = fileName;
                        int status = await context.SaveChangesAsync();
                        if (courseData.Image != null && status == 1)
                        {
                            await AddCourseImage(courseData.Image , fileName);
                        }
                    }
                    else
                    { await context.SaveChangesAsync(); }
                }
            }
            else
                throw new InvalidOperationException($"no existing course with id = {courseData.Id}");

        }
        private async Task AddCourseImage(IFormFile image , string filename)
        {
            var folderName = Path.Combine(hostEnvironment.WebRootPath , $@"Images\courses");
            Directory.CreateDirectory(folderName);

            var fullPath = Path.Combine(folderName , filename);
            using (var stream = new FileStream(fullPath , FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
        }
        private async Task DeleteCourseImage(string filename)
        {
            var folderName = Path.Combine(hostEnvironment.WebRootPath , $@"Images\courses");
            var fullPath = Path.Combine(folderName , filename);
            File.Delete(fullPath);
        }
    }
}
