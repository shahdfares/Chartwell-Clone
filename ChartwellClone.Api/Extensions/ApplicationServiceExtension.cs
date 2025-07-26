using Chartwell.Application.CompanyExpertisesServices;
using Chartwell.Application.CompanyInfoServices;
using Chartwell.Application.CompanyServices;
using Chartwell.Application.ContactsUsServices;
using Chartwell.Application.ExpertiseNewsServices;
using Chartwell.Application.IndustryServices;
using Chartwell.Application.OurFirms;
using Chartwell.Application.OverViewServices;
using Chartwell.Application.SubIndustriesService;
using Chartwell.Application.TeamMemberService;
using Chartwell.Application.TeamRolesTitle;
using Chartwell.Core.DTOs.Helper;
using Chartwell.Core.Services.Contract.CompanyExpertises;
using Chartwell.Core.Services.Contract.CompanyInfoServices;
using Chartwell.Core.Services.Contract.CompanyServices;
using Chartwell.Core.Services.Contract.ContactUsServices;
using Chartwell.Core.Services.Contract.EXpertiseNewsServices;
using Chartwell.Core.Services.Contract.Industries;
using Chartwell.Core.Services.Contract.OurFirms;
using Chartwell.Core.Services.Contract.OverViewSectionServices;
using Chartwell.Core.Services.Contract.SubIndustryServices;
using Chartwell.Core.Services.Contract.TeamMemberService;
using Chartwell.Core.Services.Contract.TeamRoleTitleServices;
using Chartwell.Infrastructure.Data;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChartwellClone.Api.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBuiltInServices();
            services.AddSwaggerServices();
            services.AddHandlingValidationErrorServices();
            services.AddDbContextServices(configuration);
            services.AddUserDefinedService();
            services.AddAutoMapperServices();

            return services;
        }

        private static IServiceCollection AddBuiltInServices(this IServiceCollection services)
        {
            // Add services to the container.

           services.AddControllers();

            return services;
        }
        private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
          services.AddEndpointsApiExplorer();
          services.AddSwaggerGen();

            return services;
        }
        private static IServiceCollection AddHandlingValidationErrorServices(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actioncontext) =>
                {
                    var errors = actioncontext.ModelState.Where(E => E.Value.Errors.Count() > 0)
                                                          .SelectMany(E => E.Value.Errors)
                                                          .Select(E => E.ErrorMessage)
                                                          .ToList();

                    var validationResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(validationResponse);  
                };
            });

            return services;
        }
        private static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChartwellDbContext>(options =>

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))

            );

            return services;
        }
        private static IServiceCollection AddUserDefinedService(this IServiceCollection services)
        {
            services.Scan(scan => scan
                    .FromAssemblyOf<UnitOfWork>()
                    .AddClasses()
                    .AsMatchingInterface()
            .WithScopedLifetime());

            services.AddScoped(typeof(ICompanyServices), typeof(CompanyServices));
            services.AddScoped(typeof(IOurFirmService), typeof(OurFirmService));
            services.AddScoped(typeof(ITeamMemberService), typeof(TeamMemberService));
            services.AddScoped(typeof(ITeamRoleTitleService), typeof(TeamRoleTitleService));
            services.AddScoped(typeof(ITeamRoleTitleService), typeof(TeamRoleTitleService));
            services.AddScoped(typeof(ICompanyExpertiseService), typeof(CompanyExpertiseService));
            services.AddScoped(typeof(IOverViewService), typeof(OverViewService));
            services.AddScoped(typeof(ICompanyInfoService), typeof(CompanyInfoService));
            services.AddScoped(typeof(IIndustryService), typeof(IndustryService));
            services.AddScoped(typeof(ISubIndustryService), typeof(SubIndustryService));
            services.AddScoped(typeof(IContactUsService), typeof(ContactUsService));
            services.AddScoped(typeof(IExpertiseNewsService), typeof(ExpertiseNewsService));

            return services;
        }
        private static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
