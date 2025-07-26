using Chartwell.Core.DTOs.TeamRoleTitles;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.Services.Contract.TeamRoleTitleServices;
using Chartwell.Core.Specification.TeamRoleTitleSpecs;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
   
    public class TeamRoleTitleController : BaseApiController
    {
        private readonly ITeamRoleTitleService _teamRole;

        public TeamRoleTitleController(ITeamRoleTitleService teamRole)
        {
           _teamRole = teamRole;
        }

        [ProducesResponseType(typeof(TeamRoleTitleToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<TeamRoleTitleToReturnDTO>> GetAllAsync([FromQuery]TeamRoleTitleSpecParams specParams)
        {
            var allRoles = await _teamRole.GetAllAsync(specParams);

            return Ok(allRoles);
        }

        [ProducesResponseType(typeof(TeamRoleTitleToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamRoleTitleToReturnDTO>> GetEntity(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _teamRole.GetEntityAsync(id);

            if(entity is null)
                return NotFound(new ApiResponse(404));

            return Ok(entity);
        }

        [ProducesResponseType(typeof(TeamRoleTitleToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<TeamRoleTitleToReturnDTO>> CreateOrUpdateAsync(TeamRoleTitleDTO roleTitleDTO)
        {
            var entity = await _teamRole.CreateOrUpdateAsync(roleTitleDTO);

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var deletedEntity = await _teamRole.DeleteAsync(id);    

            return Ok(deletedEntity);
        }
    }
}
