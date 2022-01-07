using Catharsium.Util.Configuration.Extensions;
using Catharsium.WordCloud.Interfaces;
using Catharsium.WordCloud.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.WordCloud._Configuration;

public static class Registration
{
    public static IServiceCollection AddWordCloudLogic(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Load<WordCloudSettings>();
        services.AddSingleton<WordCloudSettings, WordCloudSettings>(provider => settings);

        services.AddScoped<IWordCounter, WordCounter>();
        services.AddScoped<IWordSanitizer, WordSanitizer>();

        return services;
    }
}