using Application.RepositoryInterfaces;
using Infrastructure.EntitiesQueryParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetAll(CourseQueryParameters parameters)
        {
            var courses = courseRepository.GetAll(parameters);
            return Ok(courses);
        }
    }
}
