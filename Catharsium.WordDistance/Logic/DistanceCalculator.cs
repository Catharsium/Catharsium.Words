using Catharsium.WordDistance.Interfaces;

namespace Catharsium.WordDistance.Logic;

public class DistanceCalculator : IDistanceCalculator
{
    public int CalculateDistance(string s1, string s2)
    {
        while (true) {
            if (s1 == s2) {
                return 0;
            }

            if (s1.Length == 0 && s2.Length == 0) {
                return 0;
            }

            if (s1.Length == 0 || s2.Length == 0) {
                return Math.Abs(s1.Length - s2.Length);
            }

            if (s1[0] == s2[0]) {
                s1 = s1[1..];
                s2 = s2[1..];
                continue;
            }

            if (s1.Length == s2.Length) {
                return 1 + this.CalculateDistance(s1[1..], s2[1..]);
            }

            if (s1.Length < s2.Length) {
                return 1 + Math.Min(this.CalculateDistance(s1[1..], s2[1..]), this.CalculateDistance(s1[..], s2[1..]));
            }

            if (s1.Length > s2.Length) {
                return 1 + Math.Min(this.CalculateDistance(s1[1..], s2[..]), this.CalculateDistance(s1[1..], s2[1..]));
            }

            return 0;
        }
    }
}