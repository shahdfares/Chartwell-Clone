using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.Specification.TeamMemberSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chartwell.Core.Services.Contract.TeamMemberService
{
    public interface ITeamMemberService
    {
        Task<IReadOnlyList<TeamMemberToReturnDTO>> GetAllAsync(TeamMemberSpecsParams specsParams);
        Task<TeamMemberToReturnDTO> GetByIdAsync(int? id);
        Task<List<string>> GenerateSlugsForAllTeamMembersAsync();
        Task<TeamMemberToReturnDTO?> CreateOrUpdateAsync(TeamMemberDTO memberDTO);
        Task<bool> DeleteAsync(int? id);

    }
}
