using Chartwell.Core.DTOs.OverViewSections;
using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.Services.Contract.OverViewSectionServices;
using Chartwell.Core.Specification.OverViewSpecs;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
    
    public class OverViewController : BaseApiController
    {
        private readonly IOverViewService _overViewService;

        public OverViewController(IOverViewService overViewService)
        {
            _overViewService = overViewService;
        }

        [ProducesResponseType(typeof(OverViewToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OverViewToReturnDTO>>> GetAllAsync([FromQuery] OverViewSpecsParams specsParams)
        {
            
            var allSections = await _overViewService.GetAllAsync(specsParams);

            return Ok(allSections);
        }

        [ProducesResponseType(typeof(OverViewToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OverViewToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _overViewService.GetEntityAsync(id.Value);

            if (entity is null)
                return NotFound(new ApiResponse(404));

            return Ok(entity);
        }

        [ProducesResponseType(typeof(OverViewToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<OverViewToReturnDTO>> CreateOrUpdateAsync(overViewSectionDTO overViewSectionDTO)
        {
            var entity = await _overViewService.CreateOrUpdateAsync(overViewSectionDTO);

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Cache(100)]
        [HttpDelete]
        public async Task<ActionResult<OverViewSection>> DeleteAsync(int? id)
        {
            if(id is null)
                return BadRequest(new ApiResponse(400));

            var deletedEntity = await _overViewService.DeleteAsync(id.Value);

            return Ok(deletedEntity);
        }
    }
}
