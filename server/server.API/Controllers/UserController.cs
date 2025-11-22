using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

            return Ok(_userService.AuthorizeAsync(login, password));
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            int result;
            if (!Int32.TryParse(id, out result)) { return BadRequest("User id is empty"); }

            return Ok(_userService.GetUserAsync(result));
        }
    }
}
