using System;
using System.IO;
using Data.SqlServer;
using ProjectName.Business.Core.Interfaces.Data;
using ProjectName.Business.Core.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Startup
    {
        #region Properties

        private IConfiguration _configuration { get; }
        private ILogger<Startup> _logger { get; }

        #endregion

        #region Constructor

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _logger       = logger;
        }
        
        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add database context (ultimately will be in AddFathom extension method)
            var connectionString = Configuration.GetConnectionString();
            services.AddDbContext<ProjectNameContext>(ServiceLifetime.Scoped);
            services.AddScoped                                    ((sp) => new ProjectNameContext(connectionString));
            services.AddScoped<ProjectNameContext>                ((sp) => new ProjectNameContext(connectionString));
            services.AddScoped<IContext>                          ((sp) => new ProjectNameContext(connectionString));
            services.AddScoped<IProjectNameContext>               ((sp) => new ProjectNameContext(connectionString));




            services.Configure<RazorViewEngineOptions>(options =>
            {
                var expander = new ProjectViewLocationExpander();
                options.ViewLocationExpanders.Add(expander);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var webPort = System.Environment.GetEnvironmentVariable("WEB_PORT");
            _logger.LogInformation($"[Startup.Configure] Started on port: {webPort}");
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

        }
    }
}
