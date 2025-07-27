using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.CompanyINFO;
using Chartwell.Core.Entity.Company;
using Chartwell.Core.Services.Contract.CompanyInfoServices;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
    
    public class CompanyInfoController : BaseApiController
    {
        private readonly ICompanyInfoService _companyInfoService;

        public CompanyInfoController(ICompanyInfoService companyInfoService)
        {
            _companyInfoService = companyInfoService;
        }

        [ProducesResponseType(typeof(CompanyInfoToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyInfoToReturnDTO>>> GetAllAsync()
        {
            var allInfo = await _companyInfoService.GetAllAsync();

            return Ok(allInfo);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CompanyInfoToReturnDTO), StatusCodes.Status200OK)]
        [Cache(100)]
        [HttpPut]
        public async Task<ActionResult<CompanyInfoToReturnDTO>> UpdateAsync(CompanyInfoDTO companyInfoDTO)
        {
            var entity = await _companyInfoService.UpdateAsync(companyInfoDTO);

            if (entity is null)
                return BadRequest(new ApiResponse(400));

            return Ok(entity);

        }
    }
}
