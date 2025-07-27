using AutoMapper;
using Chartwell.Core.DTOs.Identity;
using Chartwell.Core.Entity.Identity;
using Chartwell.Core.Services.Contract.IdentityServices;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChartwellClone.Api.Controllers
{
   
    public class AccountController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService,
                                  UserManager<AppUser> userManager,
                                  IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        [HttpPost("login")] //Post: /api/Account/login
        public async Task<ActionResult<UserDto>> LogIN(LogInDto logInDTO)
        {
            var user = await _userService.LogInAsync(logInDTO);

            if (user is null)
                return Unauthorized(new ApiResponse(401));

            return Ok(user);

        }

        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("register")] //Post:/api/Account/register
        public async Task<ActionResult<UserDto>> Registeration(RegisterationDto registerationDTO)
        {
            //1. Check on an email that entered is already exist
            if (await CheckEmailExist(registerationDTO.Email))
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "This email is already in user" } });

            var result = await _userService.Registeration(registerationDTO);

            if (result is null)
                return BadRequest(new ApiResponse(400));

            return Ok(result);
        }

        [Authorize]
        [HttpGet] //Get : /api/Account
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userService.GetCurrentUserAsync(email);

            return Ok(user);
        }


        [HttpGet("emailExisted")] // Get : /api/Account/emailExisted
        public async Task<bool> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;    // if return true so email is already email 

        }
    }
}
