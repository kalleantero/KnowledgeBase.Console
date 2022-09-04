using KnowledgeBase.Console.Domain;

namespace KnowledgeBase.Console.Interfaces
{
    public interface IKnowledgeBaseService
    {
        Task<List<Answer>> FindAnswerAsync(string text);
    }
}
