using FlowResponse.Models;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        // Replace these values with your own
       var environment = "Place environment ID";
       var flowGuid = "Place Flow Id";

        // Get the list of flow runs with status 'Running'
        await CancelAllRunningFlows( environment, flowGuid);
    }

    static async Task CancelAllRunningFlows(string environment, string flowId)
    {
        int count = 0;

        using (HttpClient client = new HttpClient())
        {
            var hardToken = "Place JWT token from postman here";
            string nextLink = $"https://api.flow.microsoft.com/providers/Microsoft.ProcessSimple/environments/{environment}/flows/{flowId}/runs?api-version=2016-11-01&$filter=Status eq 'running'";
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {hardToken}");
            do
            {
                // Make a GET request to retrieve running flow runs
                var flowRunsResponse = await client.GetAsync(nextLink);

                if (flowRunsResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await flowRunsResponse.Content.ReadAsStringAsync();
                    var flowRuns = JsonConvert.DeserializeObject<FlowRuns>(jsonResponse);

                    // Display information about running runs
                    foreach (var run in flowRuns.Value)
                    {
                        await CancelFlowRun(hardToken, environment, run.Name, flowId);

                        count++;
                    }

                    // Check if there is a next link
                    nextLink = flowRuns.NextLink;
                }
                else
                {
                    Console.WriteLine($"Final amount of cancel runs {count}");
                    // Handle error if needed
                    break;
                }

            } while (!string.IsNullOrEmpty(nextLink));
        }
    }

    static async Task CancelFlowRun(string accessToken, string environment, string flowRunId, string flowGuid)
    {
        using (HttpClient client = new HttpClient())
        {
            // Construct the URL for canceling the flow run
            var urlToCancel = $"https://api.flow.microsoft.com/providers/Microsoft.ProcessSimple/environments/{environment}/flows/{flowGuid}/runs/{flowRunId}/cancel?api-version=2016-11-01";
            // Add the access token to the request headers
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // Make a POST request to cancel the flow run
            var cancelResponse = await client.PostAsync(urlToCancel, null);

            if (cancelResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Flow run canceled successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to cancel flow run. Status code: {cancelResponse.StatusCode}");
            }
        }
    }
}
