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
        public void Object(string f, string expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Object);

        [TestCase("chatResponse.00.json", "c6f2d009-77ca-40d9-9de5-6d19716e1b4d")]
        public void Id(string f, string expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Id);
        

        [TestCase("chatResponse.00.json", 1728646283)]
        public void CreatedAt(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Created);


        [TestCase("chatResponse.00.json", 15)]
        public void UsagePromptTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.PromptTokens);

        [TestCase("chatResponse.00.json", 10)]
        public void UsageCompletionTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.CompletionTokens);

        [TestCase("chatResponse.00.json", 25)]
        public void UsageTotalTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.TotalTokens);

        [TestCase("chatResponse.00.json", 15)]
        public void UsageDetailsTextTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.PromptTokensDetails?.TextTokens);

        [TestCase("chatResponse.00.json", 2)]
        public void UsageDetailsAudioTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.PromptTokensDetails?.AudioTokens);

        [TestCase("chatResponse.00.json", 3)]
        public void UsageDetailsImageTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.PromptTokensDetails?.ImageTokens);

        [TestCase("chatResponse.00.json", 4)]
        public void UsageDetailsCachedTokens(string f, long expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.Usage?.PromptTokensDetails?.CachedTokens);


        [TestCase("chatResponse.00.json", "fp_9877325691")]
        public void SystemFingerprint(string f, string expected) => AssertAreEqual<ChatResponse>(f, expected, chatResponse => chatResponse?.SystemFingerprint);
    }
}
