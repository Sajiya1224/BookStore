using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace book.Utility
{
    public class OpenAiService : IAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string? _organizationId;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OpenAiService> _logger;

        public OpenAiService(HttpClient httpClient, IConfiguration configuration, ILogger<OpenAiService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["OpenAI:ApiKey"];
            _organizationId = _configuration["OpenAI:OrganizationId"]; // optional
            _logger = logger;

            // Set a sane timeout for external API calls
            if (_httpClient.Timeout == default)
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
            }
        }

        public async Task<string> GenerateBookSummaryAsync(string bookTitle, string author, string description)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                return "AI summary generation is not configured. Please add your OpenAI API key to appsettings.json";
            }

            var prompt = $"Generate a compelling 2-3 sentence summary for the book '{bookTitle}' by {author}. " +
                        $"Here's the description: {description}. " +
                        $"Make it engaging and highlight the key themes.";

            // Prefer a current model, with automatic fallback to a widely-available one
            var primaryModel = "gpt-4o-mini";
            var fallbackModel = "gpt-3.5-turbo";

            async Task<(bool ok, string? summary, string? error)> TryRequestAsync(string model)
            {
                var requestBody = new
                {
                    model,
                    messages = new[]
                    {
                        new { role = "system", content = "You are a literary expert who writes concise, engaging book summaries." },
                        new { role = "user", content = prompt }
                    },
                    max_tokens = 150,
                    temperature = 0.7
                };

                var jsonContent = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
                if (!string.IsNullOrWhiteSpace(_organizationId))
                {
                    _httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", _organizationId);
                }

                try
                {
                    _logger.LogInformation("Requesting AI summary for book '{BookTitle}' by {Author} using model {Model}", bookTitle, author, model);
                    var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        _logger.LogWarning("AI summary request failed with {StatusCode} on model {Model}. Response: {Error}", (int)response.StatusCode, model, errorContent);
                        return (false, null, errorContent);
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonDocument.Parse(responseContent);
                    var summary = jsonResponse.RootElement
                        .GetProperty("choices")[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString();

                    return (true, summary?.Trim() ?? "Summary not available.", null);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception while generating AI summary for model {Model}", model);
                    return (false, null, ex.Message);
                }
            }

            var result = await TryRequestAsync(primaryModel);
            if (result.ok)
            {
                return result.summary!;
            }

            // Fallback attempt
            _logger.LogInformation("Falling back to model {Model} for AI summary generation", fallbackModel);
            var fallback = await TryRequestAsync(fallbackModel);
            if (fallback.ok)
            {
                return fallback.summary!;
            }

            // On failure, return empty so callers can decide not to persist an error string
            _logger.LogError("Failed to generate AI summary after trying both {PrimaryModel} and {FallbackModel}. Primary error: {PrimaryError}, Fallback error: {FallbackError}", 
                primaryModel, fallbackModel, result.error, fallback.error);
            return string.Empty;
        }
    }
}

