using Catharsium.WordCloud._Configuration;
using Catharsium.WordCloud.Interfaces;
using System.Text.RegularExpressions;
namespace Catharsium.WordCloud.Logic;

public class WordSanitizer : IWordSanitizer
{
    private readonly WordCloudSettings settings;


    public WordSanitizer(WordCloudSettings settings)
    {
        if (settings.ExcludedWords == null) {
            throw new ArgumentNullException(nameof(settings.ExcludedWords));
        }
        if (settings.WordMappings == null) {
            throw new ArgumentNullException(nameof(settings.WordMappings));
        }

        this.settings = settings;
    }


    public string Sanitize(string word)
    {
        if (word == null) {
            return word;
        }

        word = word.Trim();
        if (string.IsNullOrEmpty(word)) {
            return null;
        }
        if (this.settings.ExcludedWords.Contains(word)) {
            return null;
        }
        if (this.settings.WordMappings.ContainsKey(word)) {
            return this.settings.WordMappings[word];
        }

        return Regex.Replace(word, @"[^0-9a-zA-Z-]+", "").ToLower();
    }
}