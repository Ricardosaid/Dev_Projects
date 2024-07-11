using System.Reflection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        var isDevelopment = hostingContext.HostingEnvironment.IsDevelopment();
        if (isDevelopment)
        {
            config.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
            config.AddJsonFile("local.settings.json", optional:true, reloadOnChange:true);
        }
        else
        {
            IConfiguration settings = config.AddEnvironmentVariables().Build();
            var appConfigurationConnectionString = settings.GetValue<string>("AppConfigurationConnectionString");
            config.AddAzureAppConfiguration(options =>
            {
                options.Connect(appConfigurationConnectionString)
                    .Select(KeyFilter.Any, "DockOneConfig")
                    .UseFeatureFlags(flagOptions => flagOptions.CacheExpirationInterval = TimeSpan.FromMinutes(5));
            });
        }

    })
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
