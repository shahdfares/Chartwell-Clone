using AutoMapper;
using Chartwell.Core.DTOs.CompanyServices;
using Chartwell.Core.Entity.CompanyServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Helper
{
    public class CompanyServicesPictureUrlResolver : IValueResolver<CompanyService, CompanyServiceToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public CompanyServicesPictureUrlResolver(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public string Resolve(CompanyService source, CompanyServiceToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";

            return string.Empty;
        }
    }
}
