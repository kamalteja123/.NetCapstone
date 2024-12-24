using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models.DTO;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService; 
        }
        [HttpPost("RegisterAdmin")] 
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegisterRequestDTO userRequest) 
        { 
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState); 
            } try { 
                var response = await _userService.Register(userRequest);
                return Ok(response); 
            } catch (Exception ex) 
            { return BadRequest(new { message = ex.Message });
            } 
        }
        [HttpPost("register")]
        public async Task<ActionResult<ResponseDTO>> Register(UserRegisterRequestDTO registerRequest)
        {
            var user = await _userService.Register(registerRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            var user = await _userService.Login(loginRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
