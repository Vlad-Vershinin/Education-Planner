using Microsoft.AspNetCore.Mvc;
using server.Domain.Interfaces.Services;

namespace server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await _courseService.GetAllCoursesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(string id)
        {
            int course_id;
            if (!Int32.TryParse(id, out course_id)) { return BadRequest("Bad course id"); }

            return Ok(course_id);
        }

        [HttpGet("{id}/professions")]
        public async Task<IActionResult> GetCourseProfession(string id)
        {
            int course_id;
            if (!Int32.TryParse(id, out course_id)) { return BadRequest("Bad course id"); }

            return Ok(await _courseService.GetCourseProfessionsAsync(course_id));
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetCourseSkills(string id)
        {
            int course_id;
            if (!Int32.TryParse(id, out course_id)) { return BadRequest("Bad course id"); }

            return Ok(await _courseService.GetCourseSkillsAsync(course_id));
        }
    }
}
