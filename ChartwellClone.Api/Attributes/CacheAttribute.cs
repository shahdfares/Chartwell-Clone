using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Chartwell.Core.Services.Contract.CacheServices;

namespace ChartwellClone.Api.Attributes
{
    public class CacheAttribute : Attribute , IAsyncActionFilter
    {
        private readonly int _expirationTime;

        public CacheAttribute(int expirationTime)
        {
            _expirationTime = expirationTime;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Ask CLR to inject an object from ICacheServces Eplicitly
            var cacheServices = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            var cacheKey = GetCacheKeyFromRequest(context.HttpContext.Request);

            var cacheResponse = await cacheServices.GetCacheAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheResponse))
            {

                var contentResult = new ContentResult()
                {
                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var excutedContext = await next();

            if (excutedContext.Result is OkObjectResult response)
            {

                await cacheServices.SetCacheAsync(cacheKey, response.Value, TimeSpan.FromSeconds(_expirationTime));
            }
        }

        private string GetCacheKeyFromRequest(HttpRequest request)
        {
            var cacheKey = new StringBuilder();
            cacheKey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(X => X.Key))
            {
                cacheKey.Append($"| {key}-{value}");
            }

            return cacheKey.ToString();
        }
    
    }
}
