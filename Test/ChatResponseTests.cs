using GrokSharp.Models;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    internal class ChatResponseTests : LocalTests
    {
        [TestCase("chatResponse.00.json", "grok-2-latest")]
        public void Model(string f, string expected)
        {
            AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Model);
        }

        [TestCase("chatResponse.00.json", "chat.completion")]
        public void Object(string f, string expected)
        {
            AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Object);
        }

        [TestCase("chatResponse.00.json", "c6f2d009-77ca-40d9-9de5-6d19716e1b4d")]
        public void Id(string f, string expected)
        {
            AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Id);
        }

        [TestCase("chatResponse.00.json", 1728646283)]
        public void CreatedAt(string f, long expected)
        {
            AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Created);
        }
    }
}
