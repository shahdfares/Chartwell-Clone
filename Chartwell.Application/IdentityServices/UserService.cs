using Chartwell.Core.DTOs.Identity;
using Chartwell.Core.Entity.Identity;
using Chartwell.Core.Services.Contract.IdentityServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.IdentityServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;

        public UserService(UserManager<AppUser> userManager,
                           SignInManager<AppUser> signInManager,
                           IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }
    
        public async Task<UserDto> LogInAsync(LogInDto logInDTO)
        {
            //1. Chek on an email that entered
            var user = await _userManager.FindByEmailAsync(logInDTO.Email);

            if (user is null)
                return null;

            //2. Cken On The Password that entered
            var passwordvalid = await _signInManager.CheckPasswordSignInAsync(user, logInDTO.Password, false);

            if (!passwordvalid.Succeeded)
                return null;

            //3.Return UserDto
            return new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            };
        }

        public async Task<UserDto> Registeration(RegisterationDto registerationDTO)
        {
            // 1. Create an User
            var user = new AppUser()
            {
                Email = registerationDTO.Email,
                DisplayName = registerationDTO.DisplayName,
                PhoneNumber = registerationDTO.PhoneNumber,
                UserName = registerationDTO.Email.Split("@")[0]
            };
            var result = await _userManager.CreateAsync(user, registerationDTO.Password);

            // 2. Chek on Result 
            if (!result.Succeeded)
                return null;

            // 3. Return User DTO
            return new UserDto()
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            };
        }

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            };
        }
    }
}
