using Azure;

namespace KnowledgeBase.Console.Domain
{
    public class KnowledgeBaseConfig
    {
        public Uri Endpoint { get; set; }
        public string ProjectName { get; set; }
        public string DeploymentName { get; set; }
        public AzureKeyCredential Credential { get; set; }
    }

}
