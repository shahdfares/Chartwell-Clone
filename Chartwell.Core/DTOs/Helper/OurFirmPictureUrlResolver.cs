using AutoMapper;
using Chartwell.Core.DTOs.OurFirms;
using Chartwell.Core.Entity.OurFirms;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Helper
{
    public class OurFirmPictureUrlResolver : IValueResolver<OurFirm, OurFirmToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public OurFirmPictureUrlResolver(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public string Resolve(OurFirm source, OurFirmToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";

            return string.Empty;
        }
    }
}
