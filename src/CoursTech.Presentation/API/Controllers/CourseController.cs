﻿using Application.Parameters;
using Application.RepositoryInterfaces;
using Domain.Entities;
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
        public async Task<IActionResult> GetAll([FromQuery] CourseQueryParameters parameters)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id , [FromQuery] string[] expand)
        {
            try
            {
                var course = await courseRepository.GetById(id , expand);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Course course)
        {
            try
            {
                await courseRepository.Update(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}