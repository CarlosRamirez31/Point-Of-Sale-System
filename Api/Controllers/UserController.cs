using Application.Dtos.User.Request;
using Application.Interfaces;
using Infrastructure.Persistences.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRequestDto requestDto)
        {
            var response = await _userApplication.RegisterUser(requestDto);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<ActionResult> GenereToken([FromBody] TokenRequestDto requestDto)
        {
            var response = await _userApplication.GenerateToken(requestDto);
            return Ok(response);
        }
    }
}
