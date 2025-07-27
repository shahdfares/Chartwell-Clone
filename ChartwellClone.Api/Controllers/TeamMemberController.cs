using AutoMapper;
using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.Services.Contract.TeamMemberService;
using Chartwell.Core.Specification.TeamMemberSpecs;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
    
    public class TeamMemberController : BaseApiController
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
                                   
                                  
        {
            _teamMemberService = teamMemberService;
        }

        [ProducesResponseType(typeof(TeamMemberToReturnDTOForUsers), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TeamMemberToReturnDTOForUsers>>> GetAllAsync([FromQuery] TeamMemberSpecsParams specsParams)
        {
            var members = await _teamMemberService.GetAllAsync(specsParams);


            return Ok(members);
        }

        [ProducesResponseType(typeof(TeamMemberToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet("admin")]
        public async Task<ActionResult<IReadOnlyList<TeamMemberToReturnDTO>>> GeyAllAsync([FromQuery] TeamMemberSpecsParams specsParams)
        {

            var allMembers = await _teamMemberService.GetAllAsync(specsParams);

            return Ok(allMembers);
        }

        [ProducesResponseType(typeof(TeamMemberToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMemberToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var member = await _teamMemberService.GetByIdAsync(id.Value);

            if(member is  null) 
                return NotFound(new ApiResponse(404));

            return Ok(member);
        }

        [HttpGet("slug")]
        public async Task<ActionResult> GenerateSlugAsync()
        {
            var slugs = await _teamMemberService.GenerateSlugsForAllTeamMembersAsync();

            return Ok(slugs);   
        }

        [ProducesResponseType(typeof(TeamMemberToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost("admin")]
        public async Task<ActionResult<TeamMemberToReturnDTO>> CreateOrUpdate(TeamMemberDTO memberDTO)
        {
            var member = await _teamMemberService.CreateOrUpdateAsync(memberDTO);

            return Ok(member);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Cache(100)]
        [HttpDelete("admin")]
        public async Task<ActionResult<TeamMember>> DeleteAsync(int? id)
        {
            if(id is null)
                return BadRequest(new ApiResponse(400));

             var deletedEntity = await _teamMemberService.DeleteAsync(id.Value);

            return Ok(deletedEntity);
        }
    }
}
