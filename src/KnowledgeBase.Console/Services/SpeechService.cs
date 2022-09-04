using KnowledgeBase.Console.Domain;
using KnowledgeBase.Console.Interfaces;
using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Configuration;

namespace KnowledgeBase.Console.Services
{
    public class SpeechService : ISpeechService
    {
        private SpeechSynthesizer _speechSynthesizer;
        private SpeechRecognizer _speechRecognizer;
        public SpeechService(IConfiguration configuration)
        {
            var subscriptionKey = configuration["AzureCognitiveServices:SubscriptionKey"] ?? throw new ArgumentNullException("AzureCognitiveServices:SubscriptionKey is missing");
            var region = configuration["AzureCognitiveServices:Region"] ?? throw new ArgumentNullException("AzureCognitiveServices:Region is missing");
            // Set the voice name, refer to https://aka.ms/speech/voices/neural for full list.
            var voiceName = configuration["AzureCognitiveServices:VoiceName"] ?? throw new ArgumentNullException("AzureCognitiveServices:VoiceName is missing");

            var config = SpeechConfig.FromSubscription(subscriptionKey, region);
            config.SpeechSynthesisVoiceName = voiceName;

            _speechSynthesizer = new SpeechSynthesizer(config);
            _speechRecognizer = new SpeechRecognizer(config);
        }

        /// <summary>
        /// List speech and return speech as a text
        /// </summary>
        /// <returns></returns>
        public async Task<Text> ListenSpeechAsync()
        {
            var text = Text.Create(await _speechRecognizer.RecognizeOnceAsync());
            _speechRecognizer.Dispose();
            return text;
        }

        /// <summary>
        /// Receives plain text and reads it loud
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<Speech> ReadSpeechLoudAsync(string text)
        {
            var speech = Speech.Create(await _speechSynthesizer.SpeakTextAsync(text));
            _speechSynthesizer.Dispose();
            return speech;
        }     
       
    }
}
