using Catharsium.WordCloud._Configuration;
using Catharsium.WordCloud.Interfaces;
using System.Text.RegularExpressions;

namespace Catharsium.WordCloud.Logic;

public class WordSanitizer : IWordSanitizer
{
    private readonly WordCloudSettings settings;


    public WordSanitizer(WordCloudSettings settings)
    {
        this.settings = settings;
    }


    public string Sanitize(string word)
    {
        if(this.settings.ExcludedWords.Contains(word)) {
            return null;
        }

        if (this.settings.WordMappings.ContainsKey(word)) {
            return this.settings.WordMappings[word];
        }

        return Regex.Replace(word, @"[^0-9a-zA-Z-]+", "").ToLower();
    }
}