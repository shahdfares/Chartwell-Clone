
using ChartwellClone.Api.Extensions;
using ChartwellClone.Api.Middleware;

namespace ChartwellClone.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configuration Services
          
            webApplicationBuilder.Services.AddApplicationService(webApplicationBuilder.Configuration);
            webApplicationBuilder.Services.AddIdentityServices(webApplicationBuilder.Configuration);

            #endregion

            var app = webApplicationBuilder.Build();

            #region Middleware Configuration

            await app.MiddlewareConfigurationAsync();

            #endregion

            app.Run();
        }
    }
}
