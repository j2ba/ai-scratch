﻿namespace AI.Pad.Plugins;

public class EmailPlugin
{
	[KernelFunction]
	[Description("Sends an email to a recipient.")]
	public async Task SendEmailAsync(
		Kernel kernel,
		[Description("Semicolon delimitated list of emails of the recipients")] string recipientEmails,
		string subject,
		string body
	)
	{
		// Add logic to send an email using the recipientEmails, subject, and body
		// For now, we'll just print out a success message to the console
		await Task.Run(() => Console.WriteLine("Email sent!"));
	}
}
