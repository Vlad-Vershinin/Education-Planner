using Microsoft.AspNetCore.Mvc;
using server.Domain.Interfaces.Services;

namespace server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoryController : ControllerBase
    {
        private readonly IProfessionService _professionService;

        public RepositoryController(IProfessionService professionService)
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
            int pId;
            if (!int.TryParse(id, out pId)) return BadRequest("Profession id is incorrect");

            return Ok(await _professionService.GetProfessionAsync(pId));
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCourses(string id)
        {
            int pId;
            if (!int.TryParse(id, out pId)) return BadRequest("Profession id is incorrect");

            return Ok(await _professionService.GetProfessionCoursesAsync(pId));
        }

        [HttpGet("{id}/skills")]
        public async Task<IActionResult> GetSkills(string id)
        {
            int pId;
            if (!int.TryParse(id, out pId)) return BadRequest("Profession id is incorrect");

            return Ok(await _professionService.GetProfessionSkillsAsync(pId));
        }

    }
}
