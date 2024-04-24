namespace AI.Pad.Scripts;

public class Conversation
{
    public virtual async Task RunAsync() {
        await RunAsync("You are a helpful assistant.");
    }
    public virtual async Task RunAsync(string persona)
    {
        var kernel = Kernel.CreateBuilder().Configure().WithPlugins().Build();
        // Retrieve the chat completion service from the kernel
        IChatCompletionService chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        // Create the chat history
        ChatHistory chatMessages = new ChatHistory(persona);
        // Start the conversation
        while (true)
        {
            // Get user input
            System.Console.Write("User > ");
            chatMessages.AddUserMessage(Console.ReadLine()!);

            // Get the chat completions
            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };
            var result = chatCompletionService.GetStreamingChatMessageContentsAsync(
                chatMessages,
                executionSettings: openAIPromptExecutionSettings,
                kernel: kernel);

            // Stream the results
            string fullMessage = "";
            await foreach (var content in result)
            {
                if (content.Role.HasValue)
                {
                    System.Console.Write("Assistant > ");
                }
                System.Console.Write(content.Content);
                fullMessage += content.Content;
            }
            System.Console.WriteLine();

            // Add the message from the agent to the chat history
            chatMessages.AddAssistantMessage(fullMessage);
        }
    }
}
