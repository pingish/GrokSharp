﻿using GrokSharp;
using GrokSharp.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Net.Http.Headers;

namespace Test
{
    [TestFixture]
    internal class GrokClientTests
    {
        GrokClient _client;
        string _bearerToken;

        [SetUp]
        public void Setup()
        {
            string folder = TestContext.CurrentContext.TestDirectory;

            folder = Path.Combine(folder, "..\\..\\..\\");

            string path = Path.Combine(folder, "testSettings.json");

            if (!Path.Exists(path))
                throw new FileNotFoundException("This integration test requires a Test/testSettings.json file that contains the API KEY");

            var config = new ConfigurationBuilder()
                .SetBasePath(folder)
                .AddJsonFile("testSettings.json", optional: false)
                .Build();

            _bearerToken = config["GrokApi:BearerToken"];

            Assert.That(_bearerToken, Is.Not.Null, "Bearer token not found in appsettings.json.");

            var httpClient = new HttpClient();
            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

            _client = new GrokClient(httpClient);
        }
        [Test]
        public void BearerTokenSet()
        {
            Assert.That(_client.ApiKey, Is.EqualTo(_bearerToken));
        }

        [Test]
        public void GetModels()
        {
            var msg = _client.GetModelsAsync().Result;
            Assert.That(msg.IsSuccessStatusCode, Is.True);

            string contentAsString = msg.Content.ReadAsStringAsync().Result;
            Assert.That(contentAsString, Is.Not.Null);
        }

        [Test]
        public void GetApiKey()
        {
            var msg = _client.GetApiKeyAsync().Result;
            Assert.That(msg.IsSuccessStatusCode, Is.True);

            string contentAsString = msg.Content.ReadAsStringAsync().Result;
            Assert.That(contentAsString, Is.Not.Null);
        }

        [TestCase("Who let the dogs out?")]
        public void ChatCompletion(string prompt)
        {
            var chatRequest = new ChatRequest(prompt);
            string requestJson = chatRequest.ToJson();
            var chatResponse = _client.GetChatCompletionAsync(chatRequest).Result;
            string responseJson = chatResponse.ToJson();
        }


    }
}
