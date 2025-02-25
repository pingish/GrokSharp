namespace GrokSharp.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Payload sent to 
    /// </summary>
    public class ChatRequest
    {
        public ChatRequest()
        {
            // empty constructor for binding data
        }

        /// <summary>
        /// Construct a basic prompt
        /// </summary>
        /// <param name="prompt">The prompt for Grok</param>
        /// <param name="temperature">Default: 0 - deterministic</param>
        public ChatRequest(string prompt, double temperature = 0)
        {
            var msg = new RequestMessage { Content = prompt, Role = "user" };
            Messages.Add(msg);
            Temperature = temperature;
        }

        /// <summary>
        /// A list of messages that make up the the chat conversation. Different models support different message types, such as image and text.
        /// </summary>
        [JsonProperty("messages")]

        public IList<RequestMessage> Messages { get; set; } = [];

        /// <summary>
        /// Model name for the model to use.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; } = "grok-2-latest";

        /// <summary>
        /// If set, partial message deltas will be sent. Tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a `data: [DONE]` message.
        /// </summary>
        [JsonProperty("stream")]
        public bool Stream { get; set; } = false;

        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        public string ToJson(bool indented = true)
        {
            var formatting = indented ? Formatting.Indented : Formatting.None;
            string json = JsonConvert.SerializeObject(this, formatting);
            return json;
        }
    }
}
