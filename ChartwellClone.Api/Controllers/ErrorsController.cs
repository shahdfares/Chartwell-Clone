using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartwellClone.Api.Controllers
{
    [Route("api/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error(int code)
        {
            return code switch
            {
                400 => BadRequest("Bad Request"),
                401 => Unauthorized("Unauthorized"),
                404 => NotFound("Not Found"),
                500 => StatusCode(500, "Internal Server Error"),
                _   => StatusCode(code, "Unexpected Error")
            };
        }
    }
}
