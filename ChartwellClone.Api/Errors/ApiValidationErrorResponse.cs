using Chartwell.Core.Entity;

namespace ChartwellClone.Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ApiValidationErrorResponse() : base(400)   // Bad Request
        {
         Errors = new List<string>();   
        }
    }
}
