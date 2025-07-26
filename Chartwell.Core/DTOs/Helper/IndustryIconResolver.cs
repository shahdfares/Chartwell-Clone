using AutoMapper;
using AutoMapper.Execution;
using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.TeamMembers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Helper
{
    public class IndustryIconResolver : IValueResolver<Industry, IndustryToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public IndustryIconResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Industry source, IndustryToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.IconUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.IconUrl}";


            return string.Empty;
        }
    }
}
