using Data.SqlServer;
using ProjectName.Business.Core.Interfaces.Data;
using ProjectName.Business.Core.Models.Configuration;
using ProjectName.Presentation.Web.Models.Environment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Presentation.Web.Extensions.Startup
{
    public static class IServiceCollectionExtensions
    {
        #region Public Methods

        /// <summary>
        /// Adds all Fathom-specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public static void AddProjectNameItems(this IServiceCollection services, IConfigurationRoot configuration, IHostingEnvironment environment)
        {
            //services.AddAutoMapper();
            services.AddConfiguration(configuration, environment);
            services.AddContexts(configuration);
            services.AddRepositories();
            services.AddResponseCaching();
            services.AddConductors();
            services.AddProviders();
        }

        #endregion

        #region Private Methods

        private static void AddConfiguration(this IServiceCollection services, IConfigurationRoot configuration, IHostingEnvironment environment)
        {
            services.AddSingleton((sp) => configuration.GetSection("AccountOptions").Get<AccountOptions>());
            services.AddSingleton((sp) => configuration.GetSection("Authentication").GetSection("Cookie").Get<CookieAuthenticationConfiguration>());
            services.AddSingleton((sp) =>
            {
                var staticEnvironmentConfiguration =
                    configuration.GetSection("Environment").Get<StaticEnvironmentConfiguration>();

                if (environment.IsEnvironment("Development"))
                {
                    // If debugging, append development workstation host name to CDN domain
                    staticEnvironmentConfiguration.CDNDomain =
                        staticEnvironmentConfiguration.CDNDomain + "/" + System.Environment.MachineName;
                }
                return staticEnvironmentConfiguration;
            });

            services.AddSingleton((sp) =>
            {
                var dynamiceEnvJsonFilePath = environment.ContentRootPath + "/dynamic.env.json";
                if (System.IO.File.Exists(dynamiceEnvJsonFilePath)) {
                    // Read JSON.  Necessary
                    string dynamicEnvJson = System.IO.File.ReadAllText(dynamiceEnvJsonFilePath);

                    // Parse the object and map the dotnet mvc routes
                    dynamic dynamicEnvObject = Newtonsoft.Json.JsonConvert.DeserializeObject(dynamicEnvJson);
                    var dynamiceEnvironmentConfiguration = new DynamicEnvironmentConfiguration
                    {
                        AssetsVersionNumber = dynamicEnvObject.assetsVersionNumber
                    };

                    return dynamiceEnvironmentConfiguration;
                }
                else {
                    // File does not excist... return defaults
                    return new DynamicEnvironmentConfiguration()
                    {
                        AssetsVersionNumber = 1
                    };
                }
            });

            // Register Configuration Instance
            services.AddSingleton<IConfigurationRoot>(configuration);
        }

        private static void AddContexts(this IServiceCollection services, IConfigurationRoot configuration)
        {
            
        }

        private static void AddConductors(this IServiceCollection services)
        {
            
        }        

        private static void AddProviders(this IServiceCollection services)
        {
            
        }

        private static void AddRepositories(this IServiceCollection services)
        {

        }

        #endregion
    }
}
