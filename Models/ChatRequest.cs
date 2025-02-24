namespace GrokSharp.Models
{

    /// <summary>
    /// Payload sent to 
    /// </summary>
    public class ChatRequest
    {
        /// <summary>
        /// Gets or sets the list of messages that form the conversation context.
        /// Each message typically includes a role (e.g., "user" or "assistant") and content.
        /// Defaults to an empty list if not specified.
        /// </summary>
        public IList<RequestMessage> Messages { get; set; } = [];

        /// <summary>
        /// Gets or sets the identifier of the AI model to use for generating the response.
        /// For example, "grok" or another model name supported by the API.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response should be streamed incrementally.
        /// If true, the response is returned in chunks as it’s generated; if false, the full response is returned at once.
        /// </summary>
        public bool Stream { get; set; } = false;

        /// <summary>
        /// Gets or sets the temperature value controlling the randomness of the response.
        /// Higher values (e.g., 1 or above) increase creativity, while lower values (e.g., 0 to 1) make responses more focused and deterministic.
        /// </summary>
        public int Temperature { get; set; }

    }
}
