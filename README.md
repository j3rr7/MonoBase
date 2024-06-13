# Unity Mod Base

This repository offers a foundational C# library to streamline the development of Unity mods.  It provides core components for building custom windows, managing hotkeys, and organizing mod structures.

## Features

- **`IWindow` Interface:** Defines a consistent structure for creating and interacting with custom windows within your mod.
- **`WindowIdGenerator`:**  Generates unique identifiers for each window instance, ensuring proper management.
- **`HotkeyManager`:**  Simplifies the process of registering and handling both legacy Input and the new Input System hotkeys, allowing you to trigger actions within your windows (e.g., opening, closing, executing commands).

## Getting Started

1. **Clone the Repository:**  Download the project files.
2. **Import into Unity:** Import the `MonoBase` folder into your Unity project.
3. **Implement `IWindow`:**  Create your custom window scripts and implement the `IWindow` interface, leveraging the provided methods.
4. **Utilize Hotkey Manager:** Register hotkeys using the `HotkeyManager` class to trigger actions within your windows.

## Example (Basic Console Window):

```csharp
// BaseConsole.cs
using UnityEngine;
using MonoBase.Core;

public class BaseConsole : MonoBehaviour, IWindow 
{ 
    // ... (Implementation of IWindow interface)
}
```

# Contributing

Contributions are welcome! You can help by:

    Reporting Issues: Find bugs or suggest improvements.

    Suggesting New Features: Share ideas for enhancing the library's capabilities.

    Submitting Pull Requests: Contribute code directly by implementing new features or fixing issues.