using Catharsium.Util.Testing;
using Catharsium.WordCloud._Configuration;
using Catharsium.WordCloud.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.WordCloud.Tests.Logic
{
    [TestClass]
    public class WordSanitizerTests : TestFixture<WordSanitizer>
    {
        #region Fixture

        [TestInitialize]
        public void Initialize()
        {
            var settings = new WordCloudSettings {
                ExcludedWords = new List<string> {
                    "excluded"
                },
                WordMappings = new Dictionary<string, string> {
                    { "input", "output" }
                 }
            };
            this.SetDependency(settings);
        }

        #endregion

        #region Sanitize

        [TestMethod]
        public void Sanitize_NullWord_ReturnsNull()
        {
            var actual = this.Target.Sanitize(null);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void Sanitize_CleanWord_ReturnsWordUnchanged()
        {
            var word = "myword";
            var actual = this.Target.Sanitize(word);
            Assert.AreEqual(word, actual);
        }


        [TestMethod]
        public void Sanitize_WordInExcludedList_ReturnsNull()
        {
            var word = this.GetDependency<WordCloudSettings>().ExcludedWords[0];
            var actual = this.Target.Sanitize(word);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void Sanitize_WordInMapping_ReturnsMappedWord()
        {
            (var inputWord, var outputWord) = this.GetDependency<WordCloudSettings>().WordMappings.First();
            var actual = this.Target.Sanitize(inputWord);
            Assert.AreEqual(outputWord, actual);
        }


        [TestMethod]
        public void Sanitize_WithDigits_ReturnsWordWithDigits()
        {
            var word = "myword1";
            var actual = this.Target.Sanitize(word);
            Assert.AreEqual(word, actual);
        }


        [TestMethod]
        public void Sanitize_ReturnsWordWithoutNonWordCharacters()
        {
            var word = "(my-word)";
            var actual = this.Target.Sanitize(word);
            Assert.AreEqual("my-word", actual);
        }


        [TestMethod]
        public void Sanitize_ReturnsWordAsLowerCase()
        {
            var word = "MyWord";
            var actual = this.Target.Sanitize(word);
            Assert.AreEqual("myword", actual);
        }

        #endregion
    }
}