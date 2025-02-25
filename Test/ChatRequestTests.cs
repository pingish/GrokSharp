using GrokSharp.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    internal class ChatRequestTests : LocalTests
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

        [TestCase("chatRequest.00.json", 0, "system")]
        [TestCase("chatRequest.00.json", 1, "user")]

        public void MessageRole(string f, int i, object expected)
        {
            AssertAreEqual<ChatRequest>(f, expected, chatRequest => chatRequest?.Messages[i]?.Role);
        }

        [TestCase("chatRequest.00.json", 0, "You're an assistant")]
        [TestCase("chatRequest.00.json", 1, "Hi")]

        public void MessageContent(string f, int i, object expected)
        {
            AssertAreEqual<ChatRequest>(f, expected, chatRequest => chatRequest?.Messages[i]?.Content);
        }

        [TestCase("what is hexcolor for black?")]
        public void ConstructBasicPrompt(string prompt)
        {
            var chatRequest = new ChatRequest(prompt);

            string json = chatRequest.ToJson();
            Assert.That(prompt, Is.EqualTo(chatRequest.Messages[0].Content));
        }



    }
}
