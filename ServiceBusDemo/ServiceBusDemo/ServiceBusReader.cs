using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ServiceBusDemo
{
    public static class ServiceBusReader
    {
        [FunctionName("ServiceBusReader")]
        public static void Run([ServiceBusTrigger("NewSubscriptions", "SendSignupEmail", Connection = "ServiceBusRootConnectionString")] byte[] structuredMessage, ILogger log)
        {
            SignupInformation newAccount = SerializationHelper.DeserializeJsonMessage<SignupInformation>(structuredMessage);

            if (newAccount.AccountExists)
            {
                log.LogInformation("fix the filter on your subscription to reduce this noise.");
                return;
            }

            log.LogInformation($"C# ServiceBus topic trigger function processed message with email: {newAccount.EmailAddress}");
        }
    }
}

