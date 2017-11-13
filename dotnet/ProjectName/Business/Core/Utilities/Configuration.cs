using System;
using Microsoft.Extensions.Configuration;

namespace ProjectName.Business.Core.Utilities
{
    public static class Configuration
    {
        #region Properties

        private static IConfigurationBuilder _builder;
        private static IConfigurationRoot    _configurationRoot;

        public static IConfigurationBuilder Builder
        {
            get
            {
                if (_builder == null)
                {

                    _builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables();
                }
                return _builder;
            }
        }

        #endregion

        #region Public Methods

        public static IConfigurationRoot GetConfiguration() => _configurationRoot ?? (_configurationRoot = Builder.Build());

        public static string GetConnectionString() {
            var database = Environment.GetEnvironmentVariable("DATABASE_NAME");
            var ip       = Environment.GetEnvironmentVariable("DATABASE_IP");
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            var port     = Environment.GetEnvironmentVariable("DATABASE_PORT");
            var user     = Environment.GetEnvironmentVariable("DATABASE_USER");

            return $"Server={ip},{port}; Database={database}; user id={user}; password={password}; Integrated Security=False; MultipleActiveResultSets=True";
        }

        public static void SetConfiguration(IConfigurationRoot configuration) => _configurationRoot = configuration;

        #endregion
    }
}
