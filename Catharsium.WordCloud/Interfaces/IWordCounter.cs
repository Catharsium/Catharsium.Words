namespace Catharsium.WordCloud.Interfaces;

public interface IWordCounter
{
    Dictionary<string, int> Words { get; set; }

    void Add(params string[] texts);
}