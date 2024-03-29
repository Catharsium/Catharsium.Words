﻿using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.WordDistance.Interfaces;
using Catharsium.Words.Terminal._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Words.Terminal;

public static class Program
{
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"E:\Cloud\OneDrive\Software\Catharsium.Words\appsettings.json", false, false);
        var configuration = builder.Build();

        var serviceProvider = new ServiceCollection()
            .AddWordDistanceCommand(configuration)
            .BuildServiceProvider();

        var distanceCalculator = serviceProvider.GetService<IDistanceCalculator>();
        var similarityCalculator = serviceProvider.GetService<ISimilarityCalculator>();
        var console = serviceProvider.GetService<IConsole>();

        do {
            console.WriteLine("Enter the first word:");
            var string1 = Console.ReadLine();
            console.WriteLine("Enter the second word:");
            var string2 = Console.ReadLine();

            console.WriteLine($"The minimum distance is '{distanceCalculator.CalculateDistance(string1, string2)}'");
            console.WriteLine($"The similarity is '{similarityCalculator.CalculateSimilarity(string1, string2)}'");
            console.WriteLine();
        } while (Console.ReadLine() != "q");
    }
}