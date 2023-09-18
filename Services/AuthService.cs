using AutoDealer.Entities.DataTransferObjects.Auth;
using AutoDealer.Entities.Models.Auth;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AutoDealer.Services
{
    public class AuthException : Exception
    {
        public readonly IEnumerable<string> Errors;
        public AuthException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }

    public interface IAccountsService
    {
        Task<User> Login(LoginDto loginDto);
        Task<User> Register(RegisterDto registerDto);
    }

    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public AccountsService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<User> Register(RegisterDto registerDto)
        {
            var user = mapper.Map<User>(registerDto);
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new AuthException(errors);
            }
            await userManager.AddToRoleAsync(user, Role.Viewer);
            return user;
        }

        public async Task<User> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByNameAsync(loginDto.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                throw new Exception();
            }

            return user;
        }
    }
}