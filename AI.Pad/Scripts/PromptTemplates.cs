
namespace AI.Pad.Scripts;


public class PromptTemplates
{
    public static async Task RunAsync()
    {
        var kernel = Kernel.CreateBuilder().Configure().Build();
        ChatHistory history = [];

        var chat = kernel.CreateFunctionFromPrompt(
            @"{{$history}}
    User: {{$request}}
    Assistant: ");
    
        // Start the chat loop
        while (true)
        {
            // Get user input
            Console.Write("User > ");
            var request = Console.ReadLine();

            // Invoke prompt
            var chatResult = kernel.InvokeStreamingAsync<StreamingChatMessageContent>(
                chat,
                new()
                {
                { "request", request },
                { "history", string.Join("\n", history.Select(x => x.Role + ": " + x.Content)) }
                }
            );

            // Stream the response
            string message = "";
            await foreach (var chunk in chatResult)
            {
                if (chunk.Role.HasValue)
                {
                    Console.Write(chunk.Role + " > ");
                }

                message += chunk;
                Console.Write(chunk);
            }
            Console.WriteLine();

            // Append to history
            history.AddUserMessage(request!);
            history.AddAssistantMessage(message);
        }
    }
}
