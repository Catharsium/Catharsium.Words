using Catharsium.Util.Testing;
using Catharsium.WordDistance.Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.WordDistance.Core.Logic.Tests;

[TestClass]
public class SimilarityCalculatorTests : TestFixture<SimilarityCalculator>
{
    [TestMethod]
    public void CalculateSimilarity_MaxLengtDistance_Returns0()
    {
        var s1 = "0123456789";
        var s2 = "";
        this.GetDependency<IDistanceCalculator>().CalculateDistance(s1, s2).Returns(s1.Length);

        var actual = this.Target.CalculateSimilarity(s1, s2);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateSimilarity_HalfLengthDistance_ReturnsHalf()
    {
        var s1 = "0123456789";
        var s2 = "";
        this.GetDependency<IDistanceCalculator>().CalculateDistance(s1, s2).Returns(s1.Length / 2);

        var actual = this.Target.CalculateSimilarity(s1, s2);
        Assert.AreEqual(new decimal(0.5), actual);
    }


    [TestMethod]
    public void CalculateSimilarity_NoDistance_Returns1()
    {
        var s1 = "0123456789";
        var s2 = "";
        this.GetDependency<IDistanceCalculator>().CalculateDistance(s1, s2).Returns(0);

        var actual = this.Target.CalculateSimilarity(s1, s2);
        Assert.AreEqual(1, actual);
    }
}