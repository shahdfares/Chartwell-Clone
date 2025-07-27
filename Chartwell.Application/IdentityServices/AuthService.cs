using Chartwell.Core.Entity.Identity;
using Chartwell.Core.Services.Contract.IdentityServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.IdentityServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
            // Private Claims (User-Defined)
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.UserName),
                new Claim(ClaimTypes.Email,user.Email)

            };

            //Get User Role
            var UserRole = await userManager.GetRolesAsync(user);

            foreach (var role in UserRole)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));

            // Create Token Object 
            var token = new JwtSecurityToken(
                // Register Claims
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                expires: DateTime.UtcNow.AddDays(double.Parse(_configuration["JWT:ExpireTime"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );

            //Create Token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
    }
}
