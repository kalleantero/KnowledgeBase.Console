using KnowledgeBase.Console.Domain;

namespace KnowledgeBase.Console.Interfaces
{
    public interface ISpeechService
    {
        Task<Text> ListenSpeechAsync();
        Task<Speech> ReadSpeechLoudAsync(string text);
    }
}
