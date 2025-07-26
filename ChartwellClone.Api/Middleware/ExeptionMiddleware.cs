using ChartwellClone.Api.Errors;
using System.Net;
using System.Text.Json;

namespace ChartwellClone.Api.Middleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);           // Go To The Next Request
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);    // Development Environment

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;  // 500

                httpContext.Response.ContentType = "application/Json";

                var Response = _env.IsDevelopment() ? new ApiExeptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString())
                : new ApiExeptionResponse((int)HttpStatusCode.InternalServerError);

                // Convert the Response From an objrct to Json 
                var Json = JsonSerializer.Serialize(Response);

                await httpContext.Response.WriteAsync(Json);

            }
        }
    }
}
