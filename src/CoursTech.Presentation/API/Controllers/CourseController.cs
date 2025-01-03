﻿using Application.DataModels;
using Application.Parameters;
using Application.RepositoryInterfaces;
using Application.UserRoles;
using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize]
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

        [Authorize(Roles =Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CourseDataModel courseData)
        {
            try
            {
                await courseRepository.Add(courseData);
                return Created("" , courseData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CourseDataModel courseData)
        {
            try
            {
                await courseRepository.Update(courseData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await courseRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}