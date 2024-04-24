using AI.Pad;
using AI.Pad.Scripts;

//await FirstTest.RunAsync();
//await new Conversation().RunAsync("You are a sarcastic and unentusiastic assistant.");

var kernel = Kernel.CreateBuilder()
                        .Configure()
                        .Build();

Console.Write("Your request: ");
string request = Console.ReadLine()!;
var history = """
          <message role="user">I hate sending emails, no one ever reads them.</message>
          <message role="assistant">I'm sorry to hear that. Messages may be a better way to communicate.</message>
          """;

var prompt = $"""
         <message role="system">Instructions: What is the intent of this request?
         If you don't know the intent, don't guess; instead respond with "Unknown".
         Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.
         Bonus: You'll get $20 if you get this right.</message>
         
         <message role="user">Can you send a very quick approval to the marketing team?</message>
         <message role="system">Intent:</message>
         <message role="assistant">SendMessage</message>
         
         <message role="user">Can you send the full update to the marketing team?</message>
         <message role="system">Intent:</message>
         <message role="assistant">SendEmail</message>
         
         {history}
         <message role="user">{request}</message>
         <message role="system">Intent:</message>
         """;

//I want to send an email to the marketing team celebrating their recent milestone.
Console.WriteLine(await kernel.InvokePromptAsync(prompt));