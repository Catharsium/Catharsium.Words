using Catharsium.Util.Testing;
using Catharsium.WordCloud.Interfaces;
using Catharsium.WordCloud.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.WordCloud.Tests.Logic;

[TestClass]
public class WordCounterTests : TestFixture<WordCounter>
{
    #region Fixture

    [TestInitialize]
    public void Initialize()
    {
        this.GetDependency<IWordSanitizer>().Sanitize(Arg.Any<string>()).Returns(args => args[0]);
    }

    #endregion

    #region Add

    [TestMethod]
    public void Add_NewWord_IsAddedWithFrequency1()
    {
        var word = "catharsium";
        this.Target.Add(word);
        Assert.AreEqual(1, this.Target.Words[word]);
    }


    [TestMethod]
    public void Add_SanitizerReturnsNull_WordIsNotAdded()
    {
        var word = "catharsium";
        this.GetDependency<IWordSanitizer>().Sanitize(word).Returns(null as string);

        this.Target.Add(word);
        Assert.IsFalse(this.Target.Words.ContainsKey(word));
    }


    [TestMethod]
    public void Add_ExistingWord_FrequencyIncreasesByOne()
    {
        var word = "catharsium";
        var expected = 123;
        this.Target.Words[word] = expected - 1;

        this.Target.Add(word);
        Assert.AreEqual(expected, this.Target.Words[word]);
    }


    [TestMethod]
    public void Add_MultipleNewWords_AreAddedWithFrequency1()
    {
        var word1 = "catharsium1";
        var word2 = "catharsium2";
        var word3 = "catharsium3";
        var text = $"{word1} {word2} {word3}";

        this.Target.Add(text);
        Assert.AreEqual(1, this.Target.Words[word1]);
        Assert.AreEqual(1, this.Target.Words[word2]);
        Assert.AreEqual(1, this.Target.Words[word3]);
    }


    [TestMethod]
    public void Add_MultipleExistingWords_FrequenciesIncreasesByOne()
    {
        var word1 = "catharsium1";
        var word2 = "catharsium2";
        var word3 = "catharsium3";
        var text = $"{word1} {word2} {word3}";

        var frequency1 = 123;
        var frequency2 = 234;
        var frequency3 = 345;
        this.Target.Words[word1] = frequency1 - 1;
        this.Target.Words[word2] = frequency2 - 1;
        this.Target.Words[word3] = frequency3 - 1;

        this.Target.Add(text);
        Assert.AreEqual(frequency1, this.Target.Words[word1]);
        Assert.AreEqual(frequency2, this.Target.Words[word2]);
        Assert.AreEqual(frequency3, this.Target.Words[word3]);
    }

    #endregion
}