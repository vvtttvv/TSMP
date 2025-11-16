# DocumentEditorSystem

A C# application demonstrating design patterns using a document editing system.

## Architecture

```
DocumentEditorSystem/
├── src/
│   ├── Core/                          # Core abstractions and enums
│   │   ├── Abstractions/
│   │   │   └── DocumentComponent.cs   # Base class for composite pattern
│   │   └── Enums/
│   │       └── TextStyle.cs           # Text styling options
│   │
│   ├── Domain/                        # Business logic and models
│   │   ├── Models/
│   │   │   ├── Composite/             # COMPOSITE PATTERN
│   │   │   │   ├── Document.cs
│   │   │   │   ├── Section.cs
│   │   │   │   ├── Paragraph.cs
│   │   │   │   ├── TextElement.cs
│   │   │   │   └── ImageElement.cs
│   │   │   │
│   │   │   └── Decorators/            # DECORATOR PATTERN
│   │   │       ├── TextDecorator.cs
│   │   │       ├── BoldDecorator.cs
│   │   │       ├── ItalicDecorator.cs
│   │   │       ├── UnderlineDecorator.cs
│   │   │       └── ColorDecorator.cs
│   │   │
│   │   └── Services/
│   │       ├── IExportService.cs
│   │       └── ExportService.cs
│   │
│   ├── Application/                   # Application services
│   │   └── Facades/                   # FACADE PATTERN
│   │       └── DocumentEditorFacade.cs
│   │
│   └── Client/                        # Console application
│       └── Program.cs
```

## Design Patterns Used

1. **Composite Pattern** - Used in document structure (Document, Section, Paragraph, TextElement, ImageElement)
2. **Decorator Pattern** - Used for text styling (BoldDecorator, ItalicDecorator, UnderlineDecorator, ColorDecorator)
3. **Facade Pattern** - Simplifies complex operations with DocumentEditorFacade

## Building and Running

```bash
cd DocumentEditorSystem
dotnet build
dotnet run --project src/Client/Client.csproj
```
