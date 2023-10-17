﻿open System.IO
open System
open System.Linq
open System.Threading


//First Block is constructed in C# and is being left in for reference
//class CustomWatcher
//{
//    public void StartWatching()
//    {
//        var fw = new FileSystemWatcher
//        {
//            //Filter = "*.fs",
//            Path = "C:/Work/SieraSolutions/blog/SieraSolutionsBlog/SieraSolutionsBlog", // Any path  
//            IncludeSubdirectories = false,
//            //SynchronizingObject = (System.ComponentModel.ISynchronizeInvoke)this,
//            EnableRaisingEvents = true
//        };

//        fw.Changed += OnChange;
//    }

//    private void OnChange(object sender, FileSystemEventArgs e) => ExecuteCompilerService();

//    private void ExecuteCompilerService() {}
//}


[<EntryPoint>]
let main argv =
    //User interface
    Console.WriteLine "Watching..."

    // https://docs.microsoft.com/en-us/dotnet/api/system.io.file.copy?view=net-5.0 
    // Function to copy a file from the source to the destination
    let rec copyFile (evArgs : FileSystemEventArgs) =
        try
            File.Copy(evArgs.FullPath, "S:\\ip\\" + evArgs.Name)
        with
            | :? System.IO.IOException as ex ->
                // If there's an IOException (file in use, etc.), wait and try again
                Thread.Sleep(500)
                copyFile evArgs

    // Event handler to respond to file system events
    let handler (evArgs : FileSystemEventArgs) =
        Console.WriteLine ("Event noted: " + evArgs.FullPath)
        copyFile evArgs

    // Create a FileSystemWatcher to monitor a directory
    let watcher = new FileSystemWatcher (Path = "C:\\Users\\ipedroza\\source\\repos", IncludeSubdirectories = false, EnableRaisingEvents = true)
    
    watcher.Changed.Add(handler)
    // Wait for user input to keep the program running
    Console.ReadLine ()
    0
