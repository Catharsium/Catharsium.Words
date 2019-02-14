using Catharsium.WordDistance.Core.Logic;

namespace Catharsium.WordDistance.UI.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do {
                System.Console.WriteLine("Enter the first word:");
                var string1 = System.Console.ReadLine();
                System.Console.WriteLine("Enter the second word:");
                var string2 = System.Console.ReadLine();
                System.Console.WriteLine("The minimum distance is '{0}'", StringExtensions.DistanceTo(string1, string2));
                System.Console.WriteLine("The similarity is '{0}'", StringExtensions.SimilarityTo(string1, string2));
                System.Console.WriteLine();
            } while (System.Console.ReadLine() != "q");
        }
    }
}