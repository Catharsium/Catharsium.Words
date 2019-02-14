using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.WordDistance.Core.Logic.Tests
{
    [TestClass]
    public class DistanceCalculatorTests
    {
        [TestMethod]
        public void DistanceTo_SingleEqualLetters_ReturnsZero()
        {
            var expected = 0;
            var actual = StringExtensions.DistanceTo("a", "a");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_SingleDifferentLetters_ReturnsOne()
        {
            var expected = 1;
            var actual = StringExtensions.DistanceTo("a", "b");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_TwoEqualLetters_ReturnsZero()
        {
            var expected = 0;
            var actual = StringExtensions.DistanceTo("aa", "aa");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_SingleEqualAndSingleDifferentLetters_ReturnsOne()
        {
            var expected = 1;
            var actual = StringExtensions.DistanceTo("aa", "ab");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_TwoDifferentLetters_ReturnsTwo()
        {
            var expected = 2;
            var actual = StringExtensions.DistanceTo("ab", "cd");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_SingleLetterAndSingleEqualAndSingleDifferent_ReturnsOne()
        {
            var expected = 1;
            var actual = StringExtensions.DistanceTo("a", "ab");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_SingleLetterAndTwoDifferent_ReturnsTwo()
        {
            var expected = 2;
            var actual = StringExtensions.DistanceTo("a", "cd");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_SingleExtraLetterBeforeFirstWord_ReturnsOne()
        {
            var expected = 1;
            var actual = StringExtensions.DistanceTo("dabc", "abc");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DistanceTo_SingleExtraLetterBeforeSecondWord_ReturnsOne()
        {
            var expected = 1;
            var actual = StringExtensions.DistanceTo("abc", "dabc");
            Assert.AreEqual(expected, actual);
        }
    }
}