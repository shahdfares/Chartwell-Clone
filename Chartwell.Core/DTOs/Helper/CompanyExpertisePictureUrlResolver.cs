using AutoMapper;
using Chartwell.Core.DTOs.CompanyExpertise;
using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.Entity.ExpertisesNews;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Helper
{
    public class CompanyExpertisePictureUrlResolver : IValueResolver<Entity.ExpertisesNews.CompanyExpertise, CompanyExpertiseToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public CompanyExpertisePictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Entity.ExpertisesNews.CompanyExpertise source, CompanyExpertiseToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.pictureUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.pictureUrl}";

            return string.Empty;
        }
    }
}
