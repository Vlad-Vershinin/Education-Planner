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
        public async Task<IActionResult> GetCourse(Guid id)
        {
            return Ok(id);
        }

        [HttpGet("{id}/professions")]
        public async Task<IActionResult> GetCourseProfession(Guid id)
        {
            return Ok(await _courseService.GetCourseProfessionsAsync(id));
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetCourseSkills(Guid id)
        {
            return Ok(await _courseService.GetCourseSkillsAsync(id));
        }
    }
}
