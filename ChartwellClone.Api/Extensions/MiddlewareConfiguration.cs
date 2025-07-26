using Chartwell.Infrastructure.Data;
using ChartwellClone.Api.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChartwellClone.Api.Extensions
{
    public static class MiddlewareConfiguration
    {
        public static async Task<WebApplication> MiddlewareConfigurationAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var _dbcontext = service.GetRequiredService<ChartwellDbContext>();    // Ask CLR to Create an Object From ChartwellDbContext Explicitly
          
            var loggerfactort = service.GetRequiredService<ILoggerFactory>();

            try
            {
               await _dbcontext.Database.MigrateAsync();   // Update Database
               await ChartwellContextSeeds.SeedAsync(_dbcontext);
                 
            }
            catch (Exception ex)
            {
                // 1. Get logger
                var logger = loggerfactort.CreateLogger<Program>();

                // 2. Send Friendly Message

                logger.LogError(ex, "An Error has been occured during apply the migration");

            }



            app.UseMiddleware<ExeptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            return app;
        }
    }
}
