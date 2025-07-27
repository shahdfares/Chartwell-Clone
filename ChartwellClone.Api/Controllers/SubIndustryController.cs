using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.DTOs.SubIndustries;
using Chartwell.Core.Services.Contract.SubIndustryServices;
using Chartwell.Core.Specification.SubIndustrySpecs;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
    
    public class SubIndustryController : BaseApiController
    {
        private readonly ISubIndustryService _subIndustryService;

        public SubIndustryController(ISubIndustryService subIndustryService)
        {
            _subIndustryService = subIndustryService;
        }


        [ProducesResponseType(typeof(SubIndustryToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<SubIndustryToReturnDTO>> GetAllAsync([FromQuery] SubIndustrySpecParams specParams)
        {
            var allSubIndustries = await _subIndustryService.GetAllAsync(specParams);

            return Ok(allSubIndustries);
        }

        [ProducesResponseType(typeof(SubIndustryToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<SubIndustryToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _subIndustryService.GetByIdAsync(id.Value);

            if (entity is null)
                return NotFound(new ApiResponse(404));

            return Ok(entity);
        }


        [ProducesResponseType(typeof(SubIndustryToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<SubIndustryToReturnDTO>> CreateOrUpdateAsync(SubIndustryDTO subIndustryDTO)
        {
            var entity = await _subIndustryService.CreateOrUpdateAsync(subIndustryDTO);

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Cache(100)]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var deletedEntity = await _subIndustryService.DeleteAsync(id.Value);

            return Ok(deletedEntity);
        }
    }
}
