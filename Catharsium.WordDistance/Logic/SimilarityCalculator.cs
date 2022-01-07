using Catharsium.WordDistance.Interfaces;
namespace Catharsium.WordDistance.Logic;

public class SimilarityCalculator : ISimilarityCalculator
{
    private readonly IDistanceCalculator distanceCalculator;


    public SimilarityCalculator(IDistanceCalculator distanceCalculator)
    {
        this.distanceCalculator = distanceCalculator;
    }


    public decimal CalculateSimilarity(string s1, string s2)
    {
        var distance = this.distanceCalculator.CalculateDistance(s1, s2);
        decimal longestLength = Math.Max(s1.Length, s2.Length);
        return (longestLength - distance) / longestLength;
    }
}