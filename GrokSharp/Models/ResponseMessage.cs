using Newtonsoft.Json;

namespace GrokSharp.Models
{
    public class ResponseMessage : RequestMessage 
    {
        [JsonProperty("refusal")]
        string? Refusal { get; set; }
    }
}
