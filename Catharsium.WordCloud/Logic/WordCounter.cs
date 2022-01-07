using Catharsium.WordCloud.Interfaces;
namespace Catharsium.WordCloud.Logic;

public class WordCounter : IWordCounter
{
    private readonly IWordSanitizer wordSanitizer;

    public Dictionary<string, int> Words { get; set; } = new Dictionary<string, int>();


    public WordCounter(IWordSanitizer wordSanitizer)
    {
        this.wordSanitizer = wordSanitizer;
    }


    public void Add(params string[] texts)
    {
        foreach (var text in texts) {
            var words = text.Split(' ');
            foreach (var word in words) {
                var cleanWord = this.wordSanitizer.Sanitize(word);
                if (cleanWord == null) {
                    continue;
                }

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