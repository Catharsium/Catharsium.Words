namespace Catharsium.WordDistance.Logic;

public static class StringExtensions
{
    public static int DistanceTo(string s1, string s2)
    {
        return new DistanceCalculator().CalculateDistance(s1, s2);
    }


    public static decimal SimilarityTo(string s1, string s2)
    {
        return new SimilarityCalculator(new DistanceCalculator()).CalculateSimilarity(s1, s2);
    }
}