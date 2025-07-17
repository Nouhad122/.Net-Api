using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using University.api.Filters;
using University.Api.Helpers;
using University.Core.Forms;
using University.Core.Services;

namespace University.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtTokenHelper _jwtTokenHelper;

        public AuthController(IJwtTokenHelper jwtTokenHelper, IAuthService authService)
        {
            _authService = authService;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost("register")]
        public async Task<ApiResponse> Register([FromBody] RegisterForm form)
        {
            var dto = await _authService.Register(form);
            return new ApiResponse(dto);
        }

        [HttpPost("login")]
        public async Task<ApiResponse> Login([FromBody] LoginForm form)
        {
            var user = await _authService.Login(form);
            var token = _jwtTokenHelper.GenerateToken(user);

            return new ApiResponse(token, StatusCodes.Status200OK);
        }
    }
}