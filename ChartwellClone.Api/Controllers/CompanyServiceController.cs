using AutoMapper;
using Chartwell.Core.DTOs.CompanyServices;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Services.Contract.CompanyServices;
using ChartwellClone.Api.Attributes;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{

    public class CompanyServiceController : BaseApiController
    {
        private readonly ICompanyServices _companyServices;
      

        public CompanyServiceController(ICompanyServices companyServices)
                                        
        {
           _companyServices = companyServices;
        }

        [ProducesResponseType(typeof(CompanyServiceToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet]  // Get:/api/CompanyServices
        public async Task<ActionResult<IReadOnlyList<CompanyServiceToReturnDTO>>> GetAllAsync()
        {
            var companyServices = await _companyServices.GetAllAsync();

            return Ok(companyServices);
        }

        [ProducesResponseType(typeof(CompanyServiceToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")] // Get : /api/CompanyService/id?
        public async Task<ActionResult<CompanyServiceToReturnDTO>> GetEntity(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));        // Validation Error

            var service = await _companyServices.GetByIdAsync(id.Value);

            if (service is null)
                return NotFound(new ApiResponse(404));

            return Ok(service);
        }

        [ProducesResponseType(typeof(CompanyServiceToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("admin")] // Post: /api/CompanyService/admin
        public async Task<ActionResult<CompanyServiceToReturnDTO>> AddServiceAsync([FromBody] CompanyServicesDTO serviceDto)
        {
            var entity = await _companyServices.AddAsync(serviceDto);

            if (entity is null)
                return BadRequest(new ApiResponse(400));

            return Ok(entity);
        }

        [ProducesResponseType(typeof(CompanyService), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("admin")] // Put: /api/CompanyService/admin
        public async Task<ActionResult<CompanyServiceToReturnDTO>> UpdateAsync(CompanyServicesDTO serviceDto)
        {
            var updatedEntity = await _companyServices.UpdateAsync(serviceDto);

            if (updatedEntity is null)
                return BadRequest(new ApiResponse(400));

            return Ok(updatedEntity);

        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [Cache(100)]
        [HttpDelete("admin")] // Delete : /api/CompanyService/admin
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var service = await _companyServices.GetByIdAsync(id.Value);

            if (service is null)
                return NotFound(new ApiResponse(404));

            var deletedService = await _companyServices.DeleteAsync(id);

            return Ok(deletedService);
        }
    }
}
