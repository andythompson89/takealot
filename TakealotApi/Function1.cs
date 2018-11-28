using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TakealotApi.Api;
using TakealotApi.Models;

namespace TakealotApi
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */45 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var apiClient = new ApiClient("https://api.takealot.com/rest/v-1-6-0/productline");
            var productResult = apiClient.GET<Takealot>("PLID49432854");

            string jsonResult = JsonConvert.SerializeObject(productResult.Data.Response);
            log.LogInformation($"Timer trigger function executed: {jsonResult}");
        }
    }
}