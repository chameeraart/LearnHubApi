using LearnHubApi.Infrastructure;
using LearnHubApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }

        /// <summary>
        /// Get all Course.
        /// </summary>
        [HttpGet(Name = "GetAllCourse")]
        public IActionResult GetAll()
        {
            var courses = _course.GetAllCourse();
            return new ObjectResult(courses);
        }

        /// <summary>
        /// Get a courses by ID.
        /// </summary>
        /// <param name="id">The ID of the courses to retrieve.</param>
        [HttpGet("{id}", Name = "GetCourse")]
        public IActionResult Get(int id)
        {
            var course = _course.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return new ObjectResult(course);
        }

        /// <summary>
        /// Create a new course.
        /// </summary>
        /// <param name="course">The course object to create.</param>
        [HttpPost(Name = "CreateCourse")]
        public IActionResult Create([FromBody] Course course)
        {
            _course.InsertUpdateCourse(course);
            _course.SaveCourse();
            return CreatedAtRoute("Get", new { id = course.Id }, course);
        }

        /// <summary>
        /// Delete a course by ID.
        /// </summary>
        /// <param name="id">The ID of the course to delete.</param>
        [HttpDelete("{id}", Name = "DeleteCourse")]
        public IActionResult Delete(int id)
        {
            var course = _course.GetCourse(id);
            _course.DeleteCourse(course);
            _course.SaveCourse();
            return NoContent();
        }
    }
}
