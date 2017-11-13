using Data.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Presentation.Web.Extensions.Startup
{
    public static class IApplicationBuilderExtensions
    {
        public static void ConfigureMiddleware(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsEnvironment("Testing"))
            {
                //app.UseMiddleware<TestUserMiddleware>();
            }
        }

        public static void ConfigureSeedData(this IApplicationBuilder app, IHostingEnvironment env, IServiceScope serviceScope)
        {
            if (env.IsEnvironment("Testing"))
            {
                return;
            }

            var context = serviceScope.ServiceProvider.GetService<ProjectNameContext>();
            context.Database.Migrate();
        }
    }
}
