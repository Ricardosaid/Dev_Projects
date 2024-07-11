using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DevDemos.SlackFunction
{
    public class SlackHook
    {
        private readonly ILogger<SlackHook> _logger;
        private readonly HttpClient _httpClient;
        private readonly string? _endPoint;
        private readonly string? _userName;
        private readonly string? _password;
        private TokenObject? _tokenObject;

        public SlackHook(IConfiguration configuration, ILogger<SlackHook> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _endPoint= configuration.GetSection("DockOneConfig:Endpoint").Value;
            _userName = configuration.GetSection("DockOneConfig:UserNameCredential").Value;
            _password = configuration.GetSection("DockOneConfig:PasswordCredential").Value;
        }

        [Function("SlackHook")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _endPoint);
            var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_userName}:{_password}"));
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization",$"Basic {encodedCredentials}");
            var content = new StringContent(string.Empty);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            string responseContent = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                var tokenObject = await response.Content.ReadAsStringAsync();
                _tokenObject = JsonConvert.DeserializeObject<TokenObject>(tokenObject);
                responseContent = $"Token: {_tokenObject!.Token}";
            }
            else
            {
                responseContent = "An error ocurred while sending the message to Slack";
                _logger.LogError(responseContent);
            }
            return new OkObjectResult(responseContent);
        }

        // [Function("TimerSlack")]
        // [FixedDelayRetry(10, "00:00:10")]
        // public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo timerInfo,
        //     FunctionContext context)
        // {
        //     var slackUrl = "https://hooks.slack.com/triggers/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";
        //     
        //     string jsonText = "{\"text\":\"This is a message from Azure Functions\",\"icon_emoji\":\":ghost:\"}";
        //
        //     HttpRequestMessage slackMessage = new HttpRequestMessage(HttpMethod.Post, slackUrl);
        //     slackMessage.Content = new StringContent(jsonText, Encoding.UTF8, "application/json");
        //     HttpClient client = new HttpClient();
        //     HttpResponseMessage response = await client.SendAsync(slackMessage);
        //     if (response.IsSuccessStatusCode)
        //     {
        //         _logger.LogInformation("Message sent to Slack");
        //     }
        //     else
        //     {
        //         _logger.LogError("An error ocurred while sending the message to Slack");
        //     }
        //     
        // }
    }
    
    public class TokenObject
    {
        [JsonProperty("access_token")]
        public string Token { get; set; } = null!;
    }
    
}
