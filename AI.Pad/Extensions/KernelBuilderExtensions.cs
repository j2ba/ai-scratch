namespace AI.Pad;

public static class KernelBuilderExtensions
{
    public static IKernelBuilder Configure(this IKernelBuilder builder, string model = "gpt-3.5-turbo")
    {
        builder.Services.AddLogging(c => c.SetMinimumLevel(LogLevel.Trace).AddDebug());
        string openApiKey = Environment.GetEnvironmentVariable("OpenAPIKey");
        builder.Services.AddOpenAIChatCompletion(model, openApiKey);
        return builder;
    }

    public static IKernelBuilder WithPlugins(this IKernelBuilder builder)
    {
        builder.Plugins.AddFromType<Planners.AuthorEmailPlanner>();
        builder.Plugins.AddFromType<Plugins.EmailPlugin>();
        return builder;
    }
}
