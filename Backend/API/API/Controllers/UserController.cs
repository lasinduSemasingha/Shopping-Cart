using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Auth;
using Application.Services.Implementation;
using Application.Services.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpDTO user)
        {
            try
            {
                var result = await _userService.SignUpAsync(user);
                if(result != null)
                {
                    return Ok(result);
                }else
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }catch (Exception ex)
            {
                _logger.LogError(ex, "User creation failed");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
