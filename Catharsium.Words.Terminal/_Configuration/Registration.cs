using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.WordDistance._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Words.Terminal._Configuration;

public static class Registration
{
    public static IServiceCollection AddWordDistanceCommand(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Load<WordDistanceTerminalSettings>();
        services.AddSingleton<WordDistanceTerminalSettings, WordDistanceTerminalSettings>(provider => settings);

        services.AddConsoleIoUtilities(configuration);
        services.AddWordDistanceLogic(configuration);
        return services;
    }
}