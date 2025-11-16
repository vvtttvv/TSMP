using System;

namespace FileManager.Core.Decorators
{
    public abstract class FileSystemDecorator : IFileSystemComponent
    {
        protected readonly IFileSystemComponent _wrappee; // Wrapped component
        
        protected FileSystemDecorator(IFileSystemComponent component)
        {
            _wrappee = component ?? throw new ArgumentNullException(nameof(component));
        }
        
        public virtual string Name => _wrappee.Name;
        
        public virtual string GetInfo()
        {
            return _wrappee.GetInfo();
        }
        
        public virtual long GetSize()
        {
            return _wrappee.GetSize();
        }
        
        public virtual void Display(int indent = 0)
        {
            _wrappee.Display(indent);
        }
    }
}
