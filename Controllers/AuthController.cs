using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoDealer.Entities.DataTransferObjects.Auth;
using AutoDealer.Entities.Models.Auth;
using AutoDealer.JwtFeatures;
using AutoDealer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountsService accountsService;
        private readonly JwtHandler jwtHandler;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;


        public AuthController(IAccountsService accountsService, JwtHandler jwtHandler, UserManager<User> userManager, IMapper mapper)
        {
            this.accountsService = accountsService;
            this.jwtHandler = jwtHandler;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        private async Task<string> GenerateToken(User user)
        {
            var signingCredentials = jwtHandler.GetSigningCredentials();
            var claims = jwtHandler.GetClaims(user);

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }

            var tokenOptions = jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = await accountsService.Register(registerDto);
                var token = await GenerateToken(user);
                return Ok(new RegistrationResponseDto { Token = token, User = mapper.Map<UserProfile>(user) });
            }
            catch (AuthException ex)
            {
                return BadRequest(new RegistrationResponseDto { Errors = ex.Errors });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await accountsService.Login(loginDto);
                var token = await GenerateToken(user);
                return Ok(new AuthResponseDto { Token = token, User = mapper.Map<UserProfile>(user) });
            }
            catch (Exception)
            {
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            if (User.Identity?.Name is null)
            {
                return NotFound();
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserProfile>(user));
        }
    }
}