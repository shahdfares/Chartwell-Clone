using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Services.Contract.Industries;
using Chartwell.Core.Specification.IndustrySpecs;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
    
    public class IndustryController : BaseApiController
    {
        private readonly IIndustryService _industryService;

        public IndustryController(IIndustryService industryService)
        {
           _industryService = industryService;
        }

        [ProducesResponseType(typeof(IndustryToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]
       public async Task<ActionResult<IReadOnlyList<IndustryToReturnDTO>>> GetAllAsync([FromQuery]IndustrySpecParams specParams)
        {
            var allIndustries = await _industryService.GetAllAsync(specParams);

            return Ok(allIndustries);
        }

        [ProducesResponseType(typeof(IndustryToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<IndustryToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _industryService.GetByIdAsync(id.Value);

            if (entity is null)
                return NotFound(new ApiResponse(404));

            return Ok(entity);
        }

        [ProducesResponseType(typeof(IndustryToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<IndustryToReturnDTO>> CreateOrUpdateAsync(IndustryDTO industryDTO)
        {
            var entity = await _industryService.CreateOrUpdateAsync(industryDTO);

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Cache(100)]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if(id is  null)
                return BadRequest(new ApiResponse(400));

            var entity = await _industryService.DeleteAsync(id.Value);

            return Ok(entity);
        }
    }
}
