using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.ContactUs;
using Chartwell.Core.Entity.ContactsUs;
using Chartwell.Core.Services.Contract.ContactUsServices;
using Chartwell.Core.Specification.ContactUsSpecs;
using ChartwellClone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
   
    public class ContactUsController : BaseApiController
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [ProducesResponseType(typeof(ContactUsToReturnDTO), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> CreateAsync(ContactUsDTO contactUsDTO)
        {
            var contact = await _contactUsService.CreateAsync(contactUsDTO);

            return Ok(contact);
        }

        [ProducesResponseType(typeof(ContactUsToReturnDTO), StatusCodes.Status200OK)]
        [HttpGet("admin")]
        public async Task<ActionResult<IReadOnlyList<ContactUsToReturnDTO>>> GetAllAsync([FromQuery] ContactUsSpecParams specParams)
        {
            var allContacts = await _contactUsService.GetAllAsync(specParams);

            return Ok(allContacts);
        
        }

        [ProducesResponseType(typeof(ContactUsToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactUsToReturnDTO>> GetEntityAsync(int? id)
        {
            if (id is null)
                return BadRequest(new ApiResponse(400));

            var entity = await _contactUsService.GetEntityAsync(id.Value);

            if (entity is null)
                return NotFound(new ApiResponse(404));

            return Ok(entity);
        }

    }
}
