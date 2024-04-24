# AI Prompt Prototyping Tool

This C# project serves as a scratchpad for quickly prototyping and experimenting with AI-driven prompts, agents, copilots, and plugins using the Microsoft.SemanticKernel framework. It includes a simplified framework for executing and testing different conversational intents and responses.

## Features

- **Kernel Configuration**: Configurable kernel setup with service injection for AI models.
- **Intent Recognition**: Includes scripts for intent-based conversation handling.
- **Plugin Support**: Ability to extend functionality with custom plugins.
- **Dynamic Interaction**: Real-time user input processing with AI-generated responses.
  
## Getting Started

### Prerequisites

Ensure you have the following installed:
- .NET 6.0 SDK or later
- An IDE like Visual Studio or VSCode

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/your-username/ai-pad.git
   cd ai-pad
   ```

2. Restore and build the project:
   ```
   dotnet restore
   dotnet build
   ```

### Usage

Run the project by executing:
```
dotnet run
```

Upon running, you can interact with the system via the console, entering requests which will be processed by the configured AI model to determine intents and generate responses accordingly.

### Configuring the Kernel

The `Kernel` is configured in `Program.cs` with the following options:
- Logging setup with trace-level verbosity.
- Connection to OpenAI's API using an environment variable for the API key.
- Addition of plugins for specific tasks like email handling.

### Example Scripts

The project includes example scripts such as `Conversation.cs` that demonstrate how to set up and run a basic conversational agent with a defined persona. 

## Customization

### Adding New Plugins

To add new functionality:
1. Create a new class in the `Plugins` directory.
2. Implement your functionality.
3. Register your plugin in the `KernelBuilderExtensions` using the `WithPlugins()` method.

### Extending Conversational Capabilities

Modify the intent recognition and handling in `Program.cs` to add or change how intents are determined and processed.

## Contributing

Contributions are welcome! Please open an issue to discuss your ideas or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

Feel free to adjust the README according to your project's repository structure or additional specifics that you may wish to include.
