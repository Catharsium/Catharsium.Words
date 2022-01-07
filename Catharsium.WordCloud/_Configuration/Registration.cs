using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.WordCloud._Configuration;

public static class Registration
{
    public static IServiceCollection AddWordCloudLogic(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Load<WordCloudSettings>();
        services.AddSingleton<WordCloudSettings, WordCloudSettings>(provider => settings);

        return services;
    }
}