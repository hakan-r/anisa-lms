using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using anisa_lms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace anisa_lms.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Email is not valid." });

                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user == null) return Unauthorized(new { message = "Incorrect login credentials." });

                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
                if (!result.Succeeded) return Unauthorized(new { message = "Incorrect login credentials." });

                var roles = await _userManager.GetRolesAsync(user); // All roles assigned to this user. Returns IList
                var role = roles.FirstOrDefault() ?? "Student";

                var token = _tokenService.GenerateJwtToken(user, role);

                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });

                return Ok(new UserDto
                {
                    Id = user.Id,
                    Role = role,
                    FullName = user.FullName,
                    Token = token,
                });
            }
            catch
            {
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Email is not valid." });

                AppUser user = new()
                {
                    FullName = register.FullName,
                    Email = register.Email,
                    UserName = register.Email,
                };

                var result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded) return BadRequest(result.Errors);
                await _userManager.AddToRoleAsync(user, "Student");

                return Ok(new { message = "User registered successfully." });
            }
            catch
            {
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
            });

            return NoContent();
        }
    }
}
