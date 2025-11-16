using System;

namespace FileManager.Core.Decorators
{
    public class ReadOnlyDecorator : FileSystemDecorator
    {
        public ReadOnlyDecorator(IFileSystemComponent component) 
            : base(component)
        {
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return $"{baseInfo} [READ-ONLY]";
        }
        
        public override void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{indentation}X ");
            Console.ResetColor();
            
            _wrappee.Display(0);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{indentation}   !  Write protected");
            Console.ResetColor();
        }
    }
}