using Newtonsoft.Json;
using GrokSharp.Models;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace GrokSharp
{
    public class GrokClient
    {
        private readonly HttpClient _http;

        public GrokClient(HttpClient httpClientWithBearerToken)
        {
            _http = httpClientWithBearerToken;
        }

        /// <summary>
        /// HTTP POST to /v1/chat/completions
        /// </summary>
        /// <param name="chatRequest"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetChatCompletionAsync(ChatRequest chatRequest)
        {
            string URL_CHAT = "/v1/chat/completions";

            var payload = getPayload(chatRequest);

            var response = await _http.PostAsync(URL_CHAT, payload);

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
        HttpContent getPayload(object chatRequest)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string jsonPayload = JsonConvert.SerializeObject(chatRequest, settings);
            var payload = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            return payload;
        }

        #endregion
    }
}
