using Chartwell.Application.IdentityServices;
using Chartwell.Core.Entity.Identity;
using Chartwell.Core.Services.Contract.IdentityServices;
using Chartwell.Infrastructure.Data.Identity.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChartwellClone.Api.Extensions
{
    public static class IdentityServicesExtention
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                   .AddEntityFrameworkStores<ChartwellIdentityDbContext>();

            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromDays(double.Parse(configuration["JWT:ExpireTime"])),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]))
                };
            });

            return services;
        }
    }
}
