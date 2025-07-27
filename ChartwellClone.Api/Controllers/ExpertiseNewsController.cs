using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.ContactUs;
using Chartwell.Core.DTOs.EXpertiseNews;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Services.Contract.EXpertiseNewsServices;
using Chartwell.Core.Specification.ExpertiseNewsSpecs;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{

    public class ExpertiseNewsController : BaseApiController
    {
        private readonly IExpertiseNewsService _expertiseNewsService;

        public ExpertiseNewsController(IExpertiseNewsService expertiseNewsService)
        {
            _expertiseNewsService = expertiseNewsService;
        }

        [ProducesResponseType(typeof(ExpertiseNewsToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<ExpertiseNewsToReturnDTO>> CreateOrUpdateAsync(ExpertiseNewsDTO expertiseNewsDTO) { 
            
            var entity = await _expertiseNewsService.CreateOrUpdateAsync(expertiseNewsDTO);

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ExpertiseNewsToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ExpertiseNewsToReturnDTO>>> GetAllAsync([FromQuery] ExpertiseNewsSpecParams specParams)
        {
            var allNews = await _expertiseNewsService.GetAllAsync(specParams);

            return Ok(allNews);
        }

        [ProducesResponseType(typeof(ExpertiseNewsToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpertiseNewsToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _expertiseNewsService.GetEntityAsync(id.Value);

            if (entity is null)
                return NotFound(new ApiResponse(404));

            return Ok(entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Cache(100)]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var deletedEntity = await _expertiseNewsService.DeleteAsync(id.Value);

            return Ok(deletedEntity);
        }
    }
}
