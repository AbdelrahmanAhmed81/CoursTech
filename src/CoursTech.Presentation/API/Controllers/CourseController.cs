using Application.Parameters;
using Application.RepositoryInterfaces;
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
        public async Task<IActionResult> GetAll([FromQuery]CourseQueryParameters parameters)
        {
            try
            {
                var courses = await courseRepository.GetAll(parameters);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}