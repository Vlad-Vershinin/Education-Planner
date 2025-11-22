using Microsoft.AspNetCore.Mvc;
using server.Domain.Interfaces.Services;

namespace server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService) {
            _skillService = skillService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllSkills()
        {
            return Ok(await _skillService.GetAllSkillsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill(string id)
        {
            int skill_id;
            if (!Int32.TryParse(id, out skill_id)) { return BadRequest("Bad skill id"); }
            
            return Ok(await _skillService.GetSkillAsync(skill_id));
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetSkillCourses(string id)
        {
            int skill_id;
            if (!Int32.TryParse(id, out skill_id)) { return BadRequest("Bad skill id"); }

            return Ok(await _skillService.GetSkillCoursesAsync(skill_id));
        }

        [HttpGet("{id}/professions")]
        public async Task<IActionResult> GetSkillProfessions(string id)
        {
            int skill_id;
            if (!Int32.TryParse(id, out skill_id)) { return BadRequest("Bad skill id"); }

            return Ok(await _skillService.GetSkillProfessionsAsync(skill_id));
        }
    }
}
