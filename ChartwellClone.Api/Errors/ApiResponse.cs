
namespace ChartwellClone.Api.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statuscode, string? message = null)
        {
            StatusCode = statuscode;
            Message = message ?? GetMessageFromStatusCode(statuscode);
        }

        private string? GetMessageFromStatusCode(int statuscode)
        {
            return statuscode switch
            {
                // C# 8.0

                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _   => null

            };
        }
    }
}
