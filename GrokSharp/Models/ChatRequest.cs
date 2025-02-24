namespace GrokSharp.Models
{

    /// <summary>
    /// Payload sent to 
    /// </summary>
    public class ChatRequest
    {
        /// <summary>
        /// A list of messages that make up the the chat conversation. Different models support different message types, such as image and text.
        /// </summary>
        public IList<RequestMessage> Messages { get; set; } = [];

        /// <summary>
        /// Model name for the model to use.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// If set, partial message deltas will be sent. Tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a `data: [DONE]` message.
        /// </summary>
        public bool Stream { get; set; } = false;

        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        public double Temperature { get; set; }

    }
}
