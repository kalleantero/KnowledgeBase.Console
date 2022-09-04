using Microsoft.CognitiveServices.Speech;

namespace KnowledgeBase.Console.Domain
{
    public class Speech
    {
        public Byte[] AudioData { get; set; }
        public TimeSpan Duration { get; set; }

        public ResultReason Reason { get; set; }

        public static Speech Create(SpeechSynthesisResult result)
        {
            return new Speech()
            {
                AudioData = result.AudioData,
                Duration = result.AudioDuration,
                Reason = result.Reason
            };
        }

    }
}
