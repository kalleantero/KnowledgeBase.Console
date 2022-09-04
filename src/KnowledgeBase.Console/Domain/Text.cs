using Microsoft.CognitiveServices.Speech;

namespace KnowledgeBase.Console.Domain
{
    public class Text
    {
        public string InterpretedText { get; set; }
        public TimeSpan Duration { get; set; }

        public ResultReason Reason { get; set; }

        public static Text Create(SpeechRecognitionResult result)
        {
            return new Text()
            {
                InterpretedText = result.Text,
                Duration = result.Duration,
                Reason = result.Reason
            };
        }
    }
}
