//using MediaBrowser.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using WebsiteBuilderAPI.DTOs;
using WebsiteBuilderAPI.Services;

namespace WebsiteBuilderAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var result = await _userService.RegisterUserAsync(userDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _userService.AuthenticateUserAsync(loginDto);
            if (!result.Success)
                return Unauthorized(result.Message);

            return Ok(result);
        }
    }

}
