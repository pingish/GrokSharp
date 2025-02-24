using GrokSharp.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ChatRequestTests : LocalTests
    {

        [TestCase("chatRequest.00.json", "grok-2-latest")]
        public void Model(string f, string expected)
        {
            AssertAreEqual<ChatRequest>(f, expected, chatRequest => chatRequest?.Model);
        }

        [TestCase("chatRequest.00.json", 0)]
        public void Temperature(string f, object expected)
        {
            AssertAreEqual<ChatRequest>(f, expected, chatRequest => chatRequest?.Temperature);
        }

    }  
}
