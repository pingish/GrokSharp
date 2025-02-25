# GrokClient: C# Client for xAI's Grok

**GrokClient** is going to be a lightweight, idiomatic C# library designed to interact with xAI's Grok API. Built for .NET 8.0, it provides a simple and efficient way to integrate Grok's AI capabilities into your C# applications.

This project is not fully-baked as of Feb 2025.

## Features

- **Easy Integration**: Simple API client with minimal setup.
- **Asynchronous Support**: Full support for `async`/`await` patterns.
- **Type-Safe**: Leverages C#’s strong typing for reliable interactions.
- **Customizable**: Configurable endpoints, authentication, and request options.

## Installation

I'm just writing this for now, so there's no Nuget package.

## Usage

### Instantiating a GrokClient
The `GrokClient` is constructed by injecting an `HttpClient`.  This `HttpClient` needs to have a bearer token that is the API key gotten from xAI.

```csharp
string xAI_API_KEY; // your xAI API Key from https://console.x.ai
var http = new HttpClient(); // create new HttpClient
http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", xAI_API_KEY);

// inject HttpClient into GrokClient
var grokClient = new GrokClient(http);
```

### Making a call to Grok
There is a method, `GetChatCompletionAsync()`, that makes the call to Grok.
```csharp
// construct a request from a prompt
var chatRequest = new ChatRequest(prompt);

// making HTTP POST to the /chat/completion endpoint returns a ChatResponse object
var chatResponse = grokClient.GetChatCompletionAsync(chatRequest).Result;
```