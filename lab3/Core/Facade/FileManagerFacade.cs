using System;
using System.Collections.Generic;
using FileManager.Core.Decorators;

namespace FileManager.Core.Facade
{
    public class FileManagerFacade
    {
        private readonly Dictionary<string, IFileSystemComponent> _components;
        
        public FileManagerFacade()
        {
            _components = new Dictionary<string, IFileSystemComponent>();
        }
        
        public File CreateFile(string name, long size)
        {
            var file = new File(name, size);
            _components[name] = file;
            Console.WriteLine($"✅ Created: {file.GetInfo()}");
            return file;
        }
        
        public Folder CreateFolder(string name)
        {
            var folder = new Folder(name);
            _components[name] = folder;
            Console.WriteLine($"✅ Created: {folder.GetInfo()}");
            return folder;
        }
        
        public void AddToFolder(Folder folder, IFileSystemComponent component)
        {
            folder.Add(component);
            Console.WriteLine($"- Added '{component.Name}' to '{folder.Name}'");
        }
        
        public IFileSystemComponent ApplyCompression(IFileSystemComponent component)
        {
            var compressed = new CompressedDecorator(component);
            Console.WriteLine($"-  Applied compression to '{component.Name}'");
            return compressed;
        }
        
        public IFileSystemComponent ApplyEncryption(IFileSystemComponent component, string algorithm = "AES-256")
        {
            var encrypted = new EncryptedDecorator(component, algorithm);
            Console.WriteLine($"- Applied encryption ({algorithm}) to '{component.Name}'");
            return encrypted;
        }
        
        public IFileSystemComponent ApplyCaching(IFileSystemComponent component)
        {
            var cached = new CachedDecorator(component);
            Console.WriteLine($"- Applied caching to '{component.Name}'");
            return cached;
        }
        
        public IFileSystemComponent MakeReadOnly(IFileSystemComponent component)
        {
            var readOnly = new ReadOnlyDecorator(component);
            Console.WriteLine($"- Made '{component.Name}' read-only");
            return readOnly;
        }
       
        public IFileSystemComponent CompressAndEncrypt(IFileSystemComponent component)
        {
            Console.WriteLine($"\n- Starting compress & encrypt operation for '{component.Name}'...");
            
            var compressed = new CompressedDecorator(component);
            var encrypted = new EncryptedDecorator(compressed);
            
            Console.WriteLine($"✅ Compress & Encrypt completed!");
            return encrypted;
        }
        
        public IFileSystemComponent PrepareForBackup(IFileSystemComponent component)
        {
            Console.WriteLine($"\n!!! Preparing '{component.Name}' for backup...");
            
            var compressed = new CompressedDecorator(component);
            var encrypted = new EncryptedDecorator(compressed, "AES-256");
            var cached = new CachedDecorator(encrypted);
            var readOnly = new ReadOnlyDecorator(cached);
            
            Console.WriteLine($"✅ Backup preparation completed!");
            Console.WriteLine($"   Chain: ReadOnly → Cached → Encrypted → Compressed → Original");
            return readOnly;
        }
        
        public Folder CreateProjectStructure(string projectName)
        {
            Console.WriteLine($"\n!!!  Creating project structure for '{projectName}'... !!!");
            
            // Create root folder
            var root = CreateFolder(projectName);
            // Create subfolders
            var src = CreateFolder("src");
            var docs = CreateFolder("docs");
            var tests = CreateFolder("tests");
            // Create files
            var readme = CreateFile("README.md", 2048);
            var config = CreateFile("config.json", 512);
            var mainCs = CreateFile("Program.cs", 4096);
            var testCs = CreateFile("Tests.cs", 3072);
            
            // Build structure
            AddToFolder(root, readme);
            AddToFolder(root, config);
            AddToFolder(root, src);
            AddToFolder(root, docs);
            AddToFolder(root, tests);
            
            AddToFolder(src, mainCs);
            AddToFolder(tests, testCs);
            
            Console.WriteLine($"✅ Project structure created!");
            return root;
        }
        
        public Folder CreateSecureFolder(string folderName, params (string name, long size)[] files)
        {
            Console.WriteLine($"\n- Creating secure folder '{folderName}'...");
            
            var folder = CreateFolder(folderName);
            
            foreach (var (name, size) in files)
            {
                var file = CreateFile(name, size);
                var secured = CompressAndEncrypt(file);
                
                AddToFolder(folder, secured);
            }
            
            Console.WriteLine($"✅ Secure folder created with {files.Length} encrypted files!");
            return folder;
        }
        
        public void DisplayStructure(IFileSystemComponent component)
        {
            Console.WriteLine("---\n");
            Console.WriteLine("!!!!!!!! FILE SYSTEM STRUCTURE !!!!!!!!");
            Console.WriteLine("---\n");
            component.Display();
            Console.WriteLine("---\n");
        }

        public void ShowInfo(IFileSystemComponent component)
        {
            Console.WriteLine($"\n-  Info: {component.GetInfo()}");
            Console.WriteLine($"- Size: {component.GetSize()} bytes");
        }
        
        public IFileSystemComponent GetComponent(string name)
        {
            if (_components.TryGetValue(name, out var component))
            {
                return component;
            }
            throw new KeyNotFoundException($"Component '{name}' not found in registry");
        }
    }
}