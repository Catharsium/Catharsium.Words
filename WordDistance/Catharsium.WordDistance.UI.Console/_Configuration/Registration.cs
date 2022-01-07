using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.WordDistance.Logic._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.WordDistance.Core.Logic.Configuration;

public static class Registration
{
    public static IServiceCollection AddWordDistanceCommand(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Load<WordDistanceCommandSettings>();
        services.AddSingleton<WordDistanceCommandSettings, WordDistanceCommandSettings>(provider => settings);

        services.AddConsoleIoUtilities(configuration);
        services.AddWordDistanceLogic(configuration);
        return services;
    }
}