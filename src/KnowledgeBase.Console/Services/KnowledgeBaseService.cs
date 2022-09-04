using Azure;
using Azure.AI.Language.QuestionAnswering;
using KnowledgeBase.Console.Domain;
using KnowledgeBase.Console.Interfaces;
using Microsoft.Extensions.Configuration;

namespace KnowledgeBase.Console.Services
{
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        private QuestionAnsweringClient _questionAnsweringClient;
        private QuestionAnsweringProject _questionAnsweringProject;
        public KnowledgeBaseService(IConfiguration configuration)
        {
            var endpoint = configuration["QuestionAnswering:EndPoint"] ?? throw new ArgumentNullException("QuestionAnswering:EndPoint is missing");
            var credential = configuration["QuestionAnswering:Credential"] ?? throw new ArgumentNullException("QuestionAnswering:Credential is missing");
            var projectName = configuration["QuestionAnswering:ProjectName"] ?? throw new ArgumentNullException("QuestionAnswering:ProjectName is missing");
            var deploymentName = configuration["QuestionAnswering:DeploymentName"] ?? throw new ArgumentNullException("QuestionAnswering:DeploymentName is missing");

            var knowledgeBaseConfig = new KnowledgeBaseConfig()
            {
                Endpoint = new Uri(endpoint),
                Credential = new AzureKeyCredential(credential),
                ProjectName = projectName,
                DeploymentName = deploymentName
            };

            _questionAnsweringClient = new QuestionAnsweringClient(knowledgeBaseConfig.Endpoint, knowledgeBaseConfig.Credential);
            _questionAnsweringProject = new QuestionAnsweringProject(knowledgeBaseConfig.ProjectName, knowledgeBaseConfig.DeploymentName);
        }

        /// <summary>
        /// Find answer from Knowledge base by plain text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<List<Answer>> FindAnswerAsync(string text)
        {
            return Answer.Create(await _questionAnsweringClient.GetAnswersAsync(text, _questionAnsweringProject));
        }
    }
}
