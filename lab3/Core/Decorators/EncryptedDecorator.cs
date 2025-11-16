using System;

namespace FileManager.Core.Decorators
{
    public class EncryptedDecorator : FileSystemDecorator
    {
        private const long EncryptionOverhead = 256; // Bites for encryption header
        private readonly string _algorithm;
        
        public EncryptedDecorator(IFileSystemComponent component, string algorithm = "AES-256") 
            : base(component)
        {
            _algorithm = algorithm;
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return $"{baseInfo} [ENCRYPTED: {_algorithm}]";
        }
        
        public override long GetSize()
        {
            long originalSize = base.GetSize();
            return originalSize + EncryptionOverhead;
        }
        
        public override void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{indentation}X ");
            Console.ResetColor();
            
            _wrappee.Display(0);
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{indentation}   - Algorithm: {_algorithm}");
            Console.ResetColor();
        }
    }
}
