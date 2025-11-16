using System;
using FileManager.Core;
using FileManager.Core.Decorators;
using FileManager.Core.Facade;

// Add alias for File to avoid conflict with System.IO.File
using File = FileManager.Core.File;

namespace FileManager
{
    class Program
    {
        static void Main()
        {
            var facade = new FileManagerFacade();
            
            Demo1_CompositePattern(facade);
            Demo2_DecoratorPattern(facade);
            Demo3_CombinedDecorators(facade);
            Demo4_FacadePattern(facade);
            Demo5_ComplexScenario(facade);
            
            Console.WriteLine("\n\n✅ All demos completed!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
        static void Demo1_CompositePattern(FileManagerFacade facade)
        {
            PrintDemoHeader("DEMO 1: Composite Pattern");
            Console.WriteLine("Creating hierarchical file structure...\n");
            
            var file1 = new File("document.txt", 1024);
            var file2 = new File("image.png", 2048);
            var file3 = new File("video.mp4", 10240);
            
            var docs = new Folder("Documents");
            var media = new Folder("Media");
            var root = new Folder("Root");
            
            docs.Add(file1);
            media.Add(file2);
            media.Add(file3);
            root.Add(docs);
            root.Add(media);
            
            facade.DisplayStructure(root);
            
            Console.WriteLine($"\n- Composite Pattern");
            Console.WriteLine($"   Total size: {root.GetSize()} bytes");
            
            PressAnyKey();
        }
        
        static void Demo2_DecoratorPattern(FileManagerFacade facade)
        {
            PrintDemoHeader("DEMO 2: Decorator Pattern");
            Console.WriteLine("Applying decorators to a file...\n");
            
            var originalFile = new File("sensitive-data.txt", 4096);
            
            Console.WriteLine("Original file:");
            facade.DisplayStructure(originalFile);
            
            Console.WriteLine("\n-  Applying compression...");
            var compressed = new CompressedDecorator(originalFile);
            facade.DisplayStructure(compressed);
            
            Console.WriteLine("\n- Applying encryption...");
            var encrypted = new EncryptedDecorator(originalFile, "RSA-2048");
            facade.DisplayStructure(encrypted);
            
            Console.WriteLine("\n- Applying caching...");
            var cached = new CachedDecorator(originalFile);
            Console.WriteLine($"First call (miss): {cached.GetSize()} bytes");
            Console.WriteLine($"Second call (hit): {cached.GetSize()} bytes");
            Console.WriteLine($"Third call (hit): {cached.GetSize()} bytes");
            
            Console.WriteLine($"\n- Decorator Pattern: Dynamically adding functionality!");
            
            PressAnyKey();
        }
        
        static void Demo3_CombinedDecorators(FileManagerFacade facade)
        {
            PrintDemoHeader("DEMO 3: Combining Multiple Decorators");
            Console.WriteLine("Creating a decorator chain...\n");
            
            var file = new File("important.doc", 8192);
            
            Console.WriteLine("Building decorator chain:");
            Console.WriteLine("Original → Compressed → Encrypted → Cached → ReadOnly\n");
            
            IFileSystemComponent decorated = file;
            decorated = new CompressedDecorator(decorated);
            decorated = new EncryptedDecorator(decorated);
            decorated = new CachedDecorator(decorated);
            decorated = new ReadOnlyDecorator(decorated);
            
            facade.DisplayStructure(decorated);
            
            Console.WriteLine($"\n- Decorator Chain");
            Console.WriteLine($"   Original size: {file.GetSize()} bytes");
            Console.WriteLine($"   After decorators: {decorated.GetSize()} bytes");
            
            PressAnyKey();
        }
        
        static void Demo4_FacadePattern(FileManagerFacade facade)
        {
            PrintDemoHeader("DEMO 4: Facade Pattern");
            Console.WriteLine("Using simplified API for complex operations...\n");
            
            
            var project = facade.CreateProjectStructure("MyApp");
            facade.DisplayStructure(project);
            
            Console.WriteLine("\n- Creating secure folder with one command...");
            var secure = facade.CreateSecureFolder(
                "SecureDocuments",
                ("password.txt", 128),
                ("keys.pem", 2048),
                ("secrets.json", 512)
            );
            
            Console.WriteLine(secure.GetInfo());
            
            PressAnyKey();
        }
        
        static void Demo5_ComplexScenario(FileManagerFacade facade)
        {
            PrintDemoHeader("DEMO 5: Complex Real-World Scenario");
            Console.WriteLine("Preparing files for backup with all patterns combined...\n");
            
            var backup = facade.CreateFolder("Backup_2024");
            
            var file1 = facade.CreateFile("database.db", 50000);
            var file2 = facade.CreateFile("logs.txt", 15000);
            var file3 = facade.CreateFile("config.xml", 2048);
            
            Console.WriteLine("\n- Preparing files with different strategies...\n");
            
            var preparedDB = facade.PrepareForBackup(file1);
            var compressedLogs = facade.CompressAndEncrypt(file2);
            var cachedConfig = facade.ApplyCaching(file3);
            
            Console.WriteLine("\n Final structure:");
            facade.ShowInfo(preparedDB);
            facade.ShowInfo(compressedLogs);
            facade.ShowInfo(cachedConfig);
            
            Console.WriteLine(backup.GetInfo());
            
            PressAnyKey();
        }
        
        static void PrintDemoHeader(string title)
        {
            Console.WriteLine("\n\n" + new string('═', 60));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('═', 60));
        }
        
        static void PressAnyKey()
        {
            Console.WriteLine("\n[Press any key to continue...]");
            Console.ReadKey();
        }
    }
}