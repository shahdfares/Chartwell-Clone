using AutoMapper;
using Chartwell.Core.DTOs.OurFirms;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Services.Contract.OurFirms;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{

    public class OurFirmController : BaseApiController
    {
        private readonly IOurFirmService _ourFirmService;

        public OurFirmController(IOurFirmService  ourFirmService)
                                 
        {   
            _ourFirmService = ourFirmService;  
        }

        [ProducesResponseType(typeof(OurFirmToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet] // Get:/api/OurFirm
        public async Task<ActionResult<IReadOnlyList<OurFirmToReturnDTO>>> GetAllAsync()
        {
            var ourFirms = await _ourFirmService.GetAllAsync();

            return Ok(ourFirms);
        }

        [ProducesResponseType(typeof(OurFirmToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OurFirmToReturnDTO>> GetEntity(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var firm = await _ourFirmService.GetEntityAsync(id.Value);

            if (firm is null)
                return NotFound(new ApiResponse(404));

            return Ok(firm);
        }

        [ProducesResponseType(typeof(OurFirmToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost("admin")] // Post : /api/OurFirm/admin
        public async Task<ActionResult<OurFirmToReturnDTO>> CreateOrUpdate(OurFirmDTO  ourFirmDTO)
        {

           var Entity = await _ourFirmService.CreateOrUpdateFirm(ourFirmDTO);

            return Ok(Entity);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpDelete("admin")] // Delete : /api/OurFirm/admin
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var deletedFirm = await _ourFirmService.DeleteFirmAsync(id.Value);


            return Ok(deletedFirm);
        }
    }
}
