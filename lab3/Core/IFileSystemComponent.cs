namespace FileManager.Core
{
    public interface IFileSystemComponent
    {
        string Name { get; } // read-only property
        
        string GetInfo();
        
        long GetSize();
        
        void Display(int indent = 0); // indent will show hierarchy level visually
    }
}
