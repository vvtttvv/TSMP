using System;

// File is a leaf in the Composite pattern
namespace FileManager.Core
{
    public class File : IFileSystemComponent
    {
        public string Name { get; private set; }
        private long _size;
        private string _extension;

        public File(string name, long size)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("File name cannot be empty", nameof(name));

            if (size < 0)
                throw new ArgumentException("File size cannot be negative", nameof(size));

            Name = name;
            _size = size;
            _extension = System.IO.Path.GetExtension(name);
        }

        public string GetInfo()
        {
            return $"File: {Name} ({FormatSize(_size)})";
        }

        public long GetSize()
        {
            return _size;
        }

        public void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.WriteLine($"{indentation}- {GetInfo()}");
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
}
