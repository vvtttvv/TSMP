using System;

namespace FileManager.Core.Decorators
{
    public class CachedDecorator : FileSystemDecorator
    {
        private long? _cachedSize;
        private int _cacheHits;
        
        public CachedDecorator(IFileSystemComponent component) 
            : base(component)
        {
            _cachedSize = null;
            _cacheHits = 0;
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            string cacheInfo = _cachedSize.HasValue 
                ? $"[CACHED - Hits: {_cacheHits}]" 
                : "[NOT CACHED]";
            
            return $"{baseInfo} {cacheInfo}";
        }

        public override long GetSize()
        {
            if (_cachedSize.HasValue)
            {
                _cacheHits++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("- Cache hit! ");
                Console.ResetColor();
                return _cachedSize.Value;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("- Computing size... ");
            Console.ResetColor();

            long size = base.GetSize();
            _cachedSize = size;

            return size;
        }
        
        public void InvalidateCache()
        {
            _cachedSize = null;
            _cacheHits = 0;
        }
        
        public override void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{indentation}- ");
            Console.ResetColor();
            
            _wrappee.Display(0);
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string status = _cachedSize.HasValue 
                ? $"Cached (Hits: {_cacheHits})" 
                : "Not cached yet";
            Console.WriteLine($"{indentation}   - Cache status: {status}");
            Console.ResetColor();
        }
    }
}
