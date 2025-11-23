using Microsoft.AspNetCore.Mvc;
using server.Domain.Interfaces.Services;

namespace server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionService _professionService;

        public ProfessionController(IProfessionService professionService)
        {
            _professionService = professionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfession()
        {
            return Ok(await _professionService.GetAllProfessionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfession(string id)
        {
            Guid pId;
            if (!Guid.TryParse(id, out pId)) return BadRequest("Profession id is incorrect");

            return Ok(await _professionService.GetProfessionAsync(pId));
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCourses(string id)
        {
            Guid pId;
            if (!Guid.TryParse(id, out pId)) return BadRequest("Profession id is incorrect");

            return Ok(await _professionService.GetProfessionCoursesAsync());
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetSkills(string id)
        {
            Guid pId;
            if (!Guid.TryParse(id, out pId)) return BadRequest("Profession id is incorrect");

            return Ok(await _professionService.GetProfessionSkillsAsync());
        }

    }
}
