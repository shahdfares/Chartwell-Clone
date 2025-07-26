using Chartwell.Core.DTOs.TeamRoleTitles;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.Specification.TeamRoleTitleSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.TeamRoleTitleServices
{
    public interface ITeamRoleTitleService
    {
        Task<IReadOnlyList<TeamRoleTitleToReturnDTO>> GetAllAsync(TeamRoleTitleSpecParams specParams);
        Task<TeamRoleTitleToReturnDTO> GetEntityAsync(int? id);
        Task<TeamRoleTitleToReturnDTO> CreateOrUpdateAsync(TeamRoleTitleDTO teamRoleTitleDTO);
        Task<bool> DeleteAsync(int? id);
    }
}
