using System;

namespace Catharsium.WordDistance.Core.Logic
{
    public class SimilarityCalculator
    {
        public decimal CalculateSimilarity(string s1, string s2)
        {
            var distance = new DistanceCalculator().CalculateDistance(s1, s2);
            decimal longestLength = Math.Max(s1.Length, s2.Length);
            return (longestLength - distance)/longestLength;
        }
    }
}