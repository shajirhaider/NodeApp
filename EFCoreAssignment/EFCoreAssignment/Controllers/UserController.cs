using EFCoreAssignment.DataAccess;
using EFCoreAssignment.Models;
using EFCoreAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public UserController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseModel<AuthResponse>>> Login([FromBody] UserLoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(CustomResponseMessage.ErrorCustom("Bad Request", "Invalid request parameters?"));
            }
            var user = _applicationDbContext.Users.Where(user => user.UserName == loginDto.UserName).FirstOrDefault();

            if (user == null)
            {
                return NotFound(CustomResponseMessage.ErrorCustom("No User", "No such user"));
            }
            if (!PasswordManager.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized(CustomResponseMessage.ErrorCustom("Unauthorized", "Failed to login"));
            }
            var token = JwtAuthService.GenerateJwtToken(user, _configuration);

            return Ok(CustomResponseMessage.OkCustom("Login successful.", new AuthResponse { Token = token, user = user }));


        }


    }
}
