using Application.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryRepository industryRepository;

        public IndustryController(IIndustryRepository industryRepository)
        {
            this.industryRepository = industryRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id , [FromQuery] string[] expand)
        {
            try
            {
                var industry = await industryRepository.GetById(id , expand);
                return Ok(industry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
