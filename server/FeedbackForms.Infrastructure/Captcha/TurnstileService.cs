using System.Net.Http.Json;
using System.Text.Json.Serialization;

using FeedbackForms.Domain;
using FeedbackForms.Domain.Abstractions;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FeedbackForms.Infrastructure.Captcha;

public class TurnstileService(HttpClient httpClient, ILogger logger, IOptions<TurnstileSettings> options)
    : ITurnstileService
{
    public class TurnstileResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("error-codes")]
        public string[]? ErrorCodes { get; set; }
        [JsonPropertyName("challenge_ts")]
        public string? ChallengeTimestamp { get; set; }
        [JsonPropertyName("hostname")]
        public string? Hostname { get; set; }
    }

    const string VerifyUrl = "https://challenges.cloudflare.com/turnstile/v0/siteverify";

    public async Task<bool> ValidateTokenAsync(string token, string? remoteIp = null)
    {
        if (string.IsNullOrEmpty(token)) return false;

        var postData = new Dictionary<string, string>
        {
            { "secret", options.Value.SecretKey },
            { "response", token }
        };

        if (!string.IsNullOrEmpty(remoteIp))
            postData.Add("remoteip", remoteIp);

        var content = new FormUrlEncodedContent(postData);
        try
        {
            var response = await httpClient.PostAsync(VerifyUrl, content);
            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<TurnstileResponse>();
            logger.LogInformation(
                    "Turnstile success={Success}, errors={Errors}",
                    result?.Success,
                    result?.ErrorCodes);
            return result?.Success ?? false;
        }
        catch
        {
            return false;
        }
    }
}