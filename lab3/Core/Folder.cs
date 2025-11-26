using System;
using System.Collections.Generic;

// Folder is a composite in the Composite pattern
namespace FileManager.Core;

public class Folder : IFileSystemComponent
{
    public string Name { get; private set; }
    private List<IFileSystemComponent> _children;

    public Folder(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Folder name cannot be empty", nameof(name));

        Name = name;
        _children = new List<IFileSystemComponent>();
    }

    public void Add(IFileSystemComponent component)
    {
        if (component == null)
            throw new ArgumentNullException(nameof(component));

        if (component == this)
            throw new InvalidOperationException("Cannot add folder to itself");

        _children.Add(component);
    }

    public void Remove(IFileSystemComponent component)
    {
        if (component == null)
            throw new ArgumentNullException(nameof(component));

        _children.Remove(component);
    }

    // To not allow external modification of the children list
    public IReadOnlyList<IFileSystemComponent> GetChildren() => _children.AsReadOnly();

    public void Clear()
    {
        _children.Clear();
    }

    public string GetInfo()
    {
        int fileCount = CountFiles();
        int folderCount = CountFolders();
        return $"Folder: {Name} ({fileCount} files, {folderCount} folders, {FormatSize(GetSize())})";
    }

    public long GetSize()
    {
        // Composite delegates work to child elements
        // Summarizes sizes of all children
        long totalSize = 0;

        foreach (var child in _children)
        {
            totalSize += child.GetSize();
        }

        return totalSize;
    }

    public void Display(int indent = 0)
    {
        string indentation = new string(' ', indent * 2);
        Console.WriteLine($"{indentation}📁 {GetInfo()}");

        // Delegate display to child components
        foreach (var child in _children)
        {
            child.Display(indent + 1);
        }
    }

    private int CountFiles()
    {
        int count = 0;
        foreach (var child in _children)
        {
            if (child is File)
                count++;
            else if (child is Folder folder)
                count += folder.CountFiles();
        }
        return count;
    }

    private int CountFolders()
    {
        int count = 0;
        foreach (var child in _children)
        {
            if (child is Folder folder)
            {
                count++;
                count += folder.CountFolders();
            }
        }
        return count;
    }

    private string FormatSize(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB" };
        double len = bytes;
        int order = 0;

        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }

        return $"{len:0.##} {sizes[order]}";
    }
}