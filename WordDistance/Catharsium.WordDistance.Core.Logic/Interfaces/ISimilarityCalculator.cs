namespace Catharsium.WordDistance.Core.Logic.Interfaces;

public interface ISimilarityCalculator
{
    decimal CalculateSimilarity(string s1, string s2);
}