using System;

namespace FileManager.Core.Decorators
{
    public class CompressedDecorator : FileSystemDecorator
    {
        private const double CompressionRatio = 0.5;
        
        public CompressedDecorator(IFileSystemComponent component) 
            : base(component)
        {
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return $"{baseInfo} [COMPRESSED]";
        }
        
        public override long GetSize()
        {
            long originalSize = base.GetSize();
            long compressedSize = (long)(originalSize * CompressionRatio);
            
            return compressedSize;
        }
        
        public override void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{indentation}-  ");
            Console.ResetColor();
            
            _wrappee.Display(0);
            
            long originalSize = _wrappee.GetSize();
            long compressedSize = GetSize();
            long saved = originalSize - compressedSize;
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{indentation}   - Saved: {FormatSize(saved)} ({(1 - CompressionRatio) * 100}%)");
            Console.ResetColor();
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
