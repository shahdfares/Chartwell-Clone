using AutoMapper;
using Chartwell.Core.DTOs.CompanyINFO;
using Chartwell.Core.Entity.Company;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Helper
{
    public class CompanyInfoLogoResolver : IValueResolver<CompanyInfo, CompanyInfoToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public CompanyInfoLogoResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(CompanyInfo source, CompanyInfoToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.LogoUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.LogoUrl}";

            return string.Empty;
        }
    }
}
