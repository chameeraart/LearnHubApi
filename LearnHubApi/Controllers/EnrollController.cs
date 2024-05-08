using LearnHubApi.Infrastructure;
using LearnHubApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly IEnroll _enroll;

        public EnrollController(IEnroll enroll)
        {
            _enroll = enroll;
        }

        /// <summary>
        /// Get all enroll.
        /// </summary>
        [HttpGet(Name = "GetAllEnroll")]
        public IActionResult GetAll()
        {
            var enrolls = _enroll.GetAllEnroll();
            return new ObjectResult(enrolls);
        }

        /// <summary>
        /// Get a enrolls by ID.
        /// </summary>
        /// <param name="id">The ID of the enroll to retrieve.</param>
        [HttpGet("{id}", Name = "GetEnroll")]
        public IActionResult Get(int id)
        {
            var enroll = _enroll.GetEnroll(id);
            if (enroll == null)
            {
                return NotFound();
            }
            return new ObjectResult(enroll);
        }



        /// <summary>
        /// Get a enrolls by ID.
        /// </summary>
        /// <param name="stuid">The ID of the enroll to retrieve.</param>
        [HttpGet("enroll/{stuid}", Name = "GetEnrollUser")]
        public IActionResult GetEnrollUser(int stuid)
        {
            var enroll = _enroll.GetAllEnrollUser(stuid);
            if (enroll == null)
            {
                return NotFound();
            }
            return new ObjectResult(enroll);
        }



        /// <summary>
        /// Create a new enroll.
        /// </summary>
        /// <param name="student">The enroll object to create.</param>
        [HttpPost(Name = "CreateEnroll")]
        public IActionResult Create([FromBody]  Enroll enroll)
        {
            _enroll.InsertUpdateEnroll(enroll);
            _enroll.SaveEnroll();
            return CreatedAtRoute("Get", new { id = enroll.Id }, enroll);
        }

        /// <summary>
        /// Delete a enroll by ID.
        /// </summary>
        /// <param name="id">The ID of the enroll to delete.</param>
        [HttpDelete("{id}", Name = "DeleteEnroll")]
        public IActionResult Delete(int id)
        {
            var enroll = _enroll.GetEnroll(id);
            if (enroll == null)
            {
                return NotFound();
            }
            _enroll.DeleteEnroll(enroll);
            _enroll.SaveEnroll();
            return NoContent();
        }
    }
}
