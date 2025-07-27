using Chartwell.Core.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.IdentityServices
{
    public interface IUserService
    {
        Task<UserDto> LogInAsync(LogInDto logInDTO);
        Task<UserDto> Registeration(RegisterationDto registerationDTO);
        Task<UserDto> GetCurrentUserAsync(string email);
    }
}
