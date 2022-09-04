using Azure;
using Azure.AI.Language.QuestionAnswering;

namespace KnowledgeBase.Console.Domain
{
    public class Answer
    {
        public string Text { get; set; }
        public double? Confidence { get; set; }
        public string Source { get; set; }

        public static List<Answer> Create(Response<AnswersResult> answers)
        {
            return answers.Value.Answers.Select(x => new Answer() { Text = x.Answer, Confidence = x.Confidence, Source = x.Source }).ToList();
        }

    }
}
