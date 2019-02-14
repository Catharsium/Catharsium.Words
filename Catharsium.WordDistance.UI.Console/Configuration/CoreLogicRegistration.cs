using Catharsium.WordDistance.Core.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.WordDistance.Core.Logic.Configuration
{
    public static class CoreLogicRegistration
    {
        public static IServiceCollection AddWordDistance(this IServiceCollection services)
        {
            services.AddScoped<IDistanceCalculator, DistanceCalculator>();
            services.AddScoped<ISimilarityCalculator, SimilarityCalculator>();
            return services;
        }
    }
}