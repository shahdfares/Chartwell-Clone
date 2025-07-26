using AutoMapper;
using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.Entity.TeamMembers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Helper
{
    public class TeamMemberPictureUrlResolver : IValueResolver<TeamMember, TeamMemberToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public TeamMemberPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(TeamMember source, TeamMemberToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";
              

            return string.Empty;
        }
    }
}
