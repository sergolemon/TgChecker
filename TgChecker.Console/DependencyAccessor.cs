using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgChecker.Console.Helpers;
using TgChecker.Lib.Extensions;

namespace TgChecker.Console
{
    internal static class DependencyAccessor
    {
        private static void DependenciesInit(IServiceCollection services)
        {
            var config = ConfigurationHelper.GetConfiguration();

            services.AddSingleton<IConfiguration>(cfg =>
            {
                return config;
            });

            services.AddTgCheckerServices(config);
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            DependenciesInit(services);

            return services.BuildServiceProvider();
        }

        private static IServiceProvider serviceProvider;
        public static IServiceProvider ServiceProvider 
        { 
            get => serviceProvider ??= CreateServiceProvider();
        }
    }
}
