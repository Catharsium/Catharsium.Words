using Catharsium.WordDistance.Core.Logic.Configuration;
using Catharsium.WordDistance.Core.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.WordDistance.UI.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddWordDistance()
                .BuildServiceProvider();

            var distanceCalculator = serviceProvider.GetService<IDistanceCalculator>();
            var similarityCalculator = serviceProvider.GetService<ISimilarityCalculator>();

            do {
                System.Console.WriteLine("Enter the first word:");
                var string1 = System.Console.ReadLine();
                System.Console.WriteLine("Enter the second word:");
                var string2 = System.Console.ReadLine();

                System.Console.WriteLine("The minimum distance is '{0}'", distanceCalculator.CalculateDistance(string1, string2));
                System.Console.WriteLine("The similarity is '{0}'", similarityCalculator.CalculateSimilarity(string1, string2));
                System.Console.WriteLine();
            } while (System.Console.ReadLine() != "q");
        }
    }
}