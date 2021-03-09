open System.IO
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

    let rec copyFile (evArgs : FileSystemEventArgs) =
        try
            File.Copy(evArgs.FullPath, "S:\\ip\\" + evArgs.Name)
        with
            | :? System.IO.IOException as ex ->
                // Wait and try again
                Thread.Sleep(500)
                copyFile evArgs

    let handler (evArgs : FileSystemEventArgs) =
        Console.WriteLine ("Event noted: " + evArgs.FullPath)
        copyFile evArgs


    let watcher = new FileSystemWatcher (Path = "C:\\Users\\ipedroza\\source\\repos", IncludeSubdirectories = false, EnableRaisingEvents = true)

    watcher.Changed.Add(handler)
    
    Console.ReadLine ()
    0