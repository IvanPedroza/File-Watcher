# File Watcher in F#

This F# program demonstrates how to use the `FileSystemWatcher` class to monitor a directory for changes and automatically copy files to another location. In this example, it watches for changes in a source directory and copies any modified files to a destination directory.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) or [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework)
- A Windows environment (since the code uses Windows-specific features)

## Getting Started

1. Clone this repository to your local machine using Git.

   ```bash
   git clone https://github.com/IvanPedroza/File-Watcher.git

2. Navigate to the project directory:
   
   cd file-watcher-fsharp
   
3. Build the project using the .NET CLI:

   dotnet build
4. Run the application:

   dotnet run
   
The program will start watching the specified directory for file changes, and when a file is modified, it will be automatically copied to the destination directory.

## Configuration

You can configure the source and destination directories by modifying the code in the main function:

  let watcher = new FileSystemWatcher(Path = "{YOUR PATH HERE}", IncludeSubdirectories = false, EnableRaisingEvents = true)

You can change the Path property to the source directory you want to monitor and update the destination directory in the copyFile function.

## Troubleshooting

If you encounter any issues while running the code, please ensure that you have the required .NET runtime installed and that the specified directories are accessible.


