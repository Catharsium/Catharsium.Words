﻿using Catharsium.Util.Configuration.Extensions;
using Catharsium.WordDistance.Core.Logic.Interfaces;
using Catharsium.WordDistance.Logic._Configuration;
using Catharsium.WordDistance.Logic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.WordDistance.Core.Logic.Configuration;

public static class Registration
{
    public static IServiceCollection AddWordDistanceLogic(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Load<WordDistanceLogicSettings>();
        services.AddSingleton<WordDistanceLogicSettings, WordDistanceLogicSettings>(provider => settings);

        services.AddScoped<IDistanceCalculator, DistanceCalculator>();
        services.AddScoped<ISimilarityCalculator, SimilarityCalculator>();
        return services;
    }
}