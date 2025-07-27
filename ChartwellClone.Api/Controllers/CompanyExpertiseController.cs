using Chartwell.Core.DTOs.CompanyExpertise;
using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Services.Contract.CompanyExpertises;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
   
    public class CompanyExpertiseController : BaseApiController
    {
        private readonly ICompanyExpertiseService _companyExpertiseService;

        public CompanyExpertiseController(ICompanyExpertiseService companyExpertiseService)
        {
           _companyExpertiseService = companyExpertiseService;
        }

        [ProducesResponseType(typeof(CompanyExpertiseToReturnDTO), StatusCodes.Status200OK )]
        [HttpGet]
        public async Task<ActionResult<CompanyExpertiseToReturnDTO>> GetAllAsync()
        {
            var allExpertise = await _companyExpertiseService.GetAllAsync();

            return Ok(allExpertise);
        }

        [ProducesResponseType(typeof(CompanyExpertiseToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyExpertiseToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var expertise = await _companyExpertiseService.GetEntityAsync(id.Value);

            if (expertise is null)
                return NotFound(new ApiResponse(400));

            return Ok(expertise);
        }

        [HttpGet("slug")]
        public async Task<ActionResult> GenerateSlug()
        {
            var slug = await _companyExpertiseService.GenerateSlugAsync();

            return Ok(slug);
        }


        [ProducesResponseType(typeof(CompanyExpertiseToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<CompanyExpertiseToReturnDTO>> CreateOrUpdateAsync(CompanyExpertiseDTO companyExpertiseDTO)
        {
            var entity = await _companyExpertiseService.CreateOrUpdateAsync(companyExpertiseDTO);

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Cache(100)]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _companyExpertiseService.DeleteAsync(id.Value);

            return Ok(entity);
        }
    }
}
