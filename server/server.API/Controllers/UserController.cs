using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using server.Domain.DTOs;
using server.Domain.Interfaces.Services;

namespace server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet("auth/{login}/{password}")]
        public async Task<IActionResult> Authorize(string login, string password)
        {
            if (string.IsNullOrEmpty(login)) { return BadRequest("Login is empty"); }
            if (string.IsNullOrEmpty(password)) { return BadRequest("Password is empty"); }

            return Ok(await _userService.AuthorizeAsync(login, password));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            Guid user_id;
            if (!Guid.TryParse(id, out user_id)) { return BadRequest("User id is empty"); }

            return Ok(await _userService.GetUserAsync(user_id));
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetUserCourses(string id)
        {
            Guid user_id;
            if (!Guid.TryParse(id, out user_id)) { return BadRequest("User id is empty"); }

            return Ok(await _userService.GetUserCoursesAsync(user_id));
        }

        [HttpGet("{id}/profession")]
        public async Task<IActionResult> GetUserProfession(string id)
        {
            Guid user_id;
            if (!Guid.TryParse(id, out user_id)) { return BadRequest("User id is incorrect"); }

            return Ok(await _userService.GetUserProfessionAsync(user_id));
        }

        [HttpPost("{user_id}/skills")]
        public async Task<IActionResult> UpdateUserSkills(string user_id, [FromBody] List<LeveledSkillDto> leveledSkillDtos)
        {
            Guid Id;
            if (!Guid.TryParse(user_id, out Id)) { return BadRequest("User id is incorrect"); }

            await _userService.UpdateUserSkillsAsync(Id, leveledSkillDtos);

            return Ok();
        }

        [HttpPost("{user_id}/courses/{course_id}")]
        public async Task<IActionResult> UpdateUserCourseProgress(string user_id, string course_id, [FromBody] double progress)
        {
            Guid user;
            Guid course;
            if (!Guid.TryParse(user_id, out user)) { return BadRequest("User id is incorrect"); }
            if (!Guid.TryParse(course_id, out course)) { return BadRequest("Course id is incorrect"); }

            await _userService.UpdateUserCourseProgressAsync(user, course, progress);

            return Ok();
        }

        [HttpPost("{user_id}/profession")]
        public async Task<IActionResult> UpdateUserProfession(string user_id, [FromBody] Guid profession_id)
        {
            Guid Id;
            if (!Guid.TryParse(user_id, out Id)) { return BadRequest("User id is incorrect"); }

            await _userService.UpdateUserProfessionAsync(Id, profession_id);

            return Ok();
        }
    }
}
