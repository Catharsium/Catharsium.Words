using Catharsium.WordCloud.Interfaces;
using System.Text.RegularExpressions;
namespace Catharsium.WordCloud.Logic;

public class WordCounter : IWordCounter
{

    public Dictionary<string, int> Words { get; set; } = new Dictionary<string, int>();


    public void Add(params string[] texts)
    {
        foreach (var text in texts) {
            var words = text.Split(' ');
            foreach (var word in words) {
                var cleanWord = Regex.Replace(word, @"[^0-9a-zA-Z-]+", "").ToLower();
                if (this.Words.ContainsKey(cleanWord)) {
                    this.Words[cleanWord]++;
                }
                else {
                    this.Words.Add(cleanWord, 1);
                }
            }
        }
    }
}