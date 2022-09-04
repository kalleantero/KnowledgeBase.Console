using KnowledgeBase.Console.Services;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

Console.WriteLine("Hello, KnowledgeBase app is running!");

var speechService = new SpeechService(configuration);
var knowledgeBaseService = new KnowledgeBaseService(configuration);

Console.WriteLine("Ask a question...");

var question = await speechService.ListenSpeechAsync();

Console.WriteLine($"Your question was: {question.InterpretedText}");

var answer = await knowledgeBaseService.FindAnswerAsync(question.InterpretedText);

Console.WriteLine($"Text answer: {question.InterpretedText}");

var result = await speechService.ReadSpeechLoudAsync(answer[0].Text);