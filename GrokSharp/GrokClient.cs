using GrokSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace GrokSharp
{
    public class GrokClient
    {
        private readonly HttpClient _http;

        public GrokClient(HttpClient httpClientWithBearerToken)
        {
            _http = httpClientWithBearerToken;
            _http.BaseAddress = new Uri("https://api.x.ai/");
        }

        public string? ApiKey => _http?.DefaultRequestHeaders?.Authorization?.ToString().Replace("Bearer ", "");


        /// <summary>
        /// HTTP POST to /v1/chat/completions
        /// </summary>
        /// <param name="chatRequest"></param>
        /// <returns></returns>
        public async Task<ChatResponse> GetChatCompletionAsync(ChatRequest chatRequest)
        {
            string URL_CHAT = "/v1/chat/completions";

            var payload = getPayload(chatRequest.ToJson());

            var msg = await _http.PostAsync(URL_CHAT, payload);

            msg.EnsureSuccessStatusCode();

            string json = await msg.Content.ReadAsStringAsync();

            var chatResponse = JsonConvert.DeserializeObject<ChatResponse>(json);

            return chatResponse;
        }

        /// <summary>
        /// HTTP GET /v1/api-key
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetApiKeyAsync()
        {
            string URL = "/v1/api-key";

            var response = await _http.GetAsync(URL);

            return response;
        }

        /// <summary>
        /// HTTP GET /v1/models
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetModelsAsync()
        {
            string URL = "/v1/models";

            var response = await _http.GetAsync(URL);

            return response;
        }

        #region helper functions

        /// <summary>
        /// Converts a chat request object into an HTTP content payload for a POST request.
        /// </summary>
        /// <param name="chatRequest">The object containing chat request data to serialize, such as a ChatRequest instance.</param>
        /// <returns>An <see cref="HttpContent"/> object containing the JSON-serialized payload, formatted with UTF-8 encoding and "application/json" media type.</returns>
        /// <remarks>
        /// The serialization uses default Newtonsoft.Json settings. To use camelCase property names, configure a <see cref="JsonSerializerSettings"/> with a <see cref="CamelCasePropertyNamesContractResolver"/>.
        /// </remarks>
        HttpContent getPayload(string jsonPayload)
        {
            var payload = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            return payload;
        }

        #endregion
    }
}
