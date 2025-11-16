# Laboratory Work No.3 — Structural Design Patterns

**Author:** Titerez Vladislav  
**Course:** TMPS  
**Topic:** Structural Design Patterns

---

## Table of Contents

1. [Objectives](#objectives)
2. [Theory](#theory)
3. [Domain Area](#domain-area)
4. [Implementation](#implementation)
    - 4.1 [Project Structure](#project-structure)
    - 4.2 [Design Patterns](#design-patterns)
    - 4.3 [Class Descriptions](#class-descriptions)
5. [Usage Examples](#usage-examples)
6. [Results](#results)
7. [Conclusions](#conclusions)

---

## 1. Objectives

The main objectives of this laboratory work are:

* **Study and understand Structural Design Patterns** — examine patterns that simplify relationships between objects.
* **Apply selected patterns in code** — demonstrate practical use of at least three structural design patterns.
* **Model a relevant domain** — use clear classes and abstractions based on a practical context.
* **Follow SOLID principles** — ensure clean, extensible, and maintainable codebase.

---

## 2. Theory

### 2.1 What are Structural Design Patterns?

**Structural design patterns** are patterns that ease the design by identifying a simple way to realize relationships among entities. These patterns help ensure that if one part of a system changes, the entire system doesn't need to do the same.

### 2.2 Types of Structural Patterns

Common structural patterns include:

* **Adapter** — Allows the interface of an existing class to be used as another interface.
* **Bridge** — Decouples abstraction from implementation so they can vary independently.
* **Composite** — Composes objects into tree structures to represent part-whole hierarchies.
* **Decorator** — Adds additional responsibilities to an object dynamically.
* **Facade** — Provides a simplified interface to a complex subsystem.
* **Flyweight** — Reduces memory usage by sharing as much data as possible with similar objects.
* **Proxy** — Provides a surrogate or placeholder for another object.

### 2.3 Why Use Structural Patterns?

* **Simplify code structure** — Reduce complexity by organizing relationships and responsibilities clearly.
* **Increase flexibility** — Make code easier to extend and adjust.
* **Encapsulation** — Hide intricate implementation details behind clean interfaces.
* **Reusability and Maintainability** — Easier to reuse components and maintain code over time.

---

## 3. Domain Area

**Domain Selected:** [Specify your system — for example, Computer Peripherals Connector, Document Editor Components, etc.]

(This part should be adapted to your specific structural patterns’ context; if lab3 is about wrapping and combining hardware devices or document elements, explain it here.)

The selected domain demonstrates the need for flexible, extensible interconnections and composition. For example:

* **Adapting** new device interfaces to existing protocols.
* **Composing** simple and complex device components or document elements in trees.
* **Extending** component behavior at runtime.

---

## 4. Implementation

### 4.1 Project Structure

```
lab3/
│
├── Core/              # Core abstractions and component logic
│   ├── [Adapters]     # Adapter classes for interface conversion
│   ├── [Composites]   # Composite pattern implementation
│   ├── [Decorators]   # Decorator logic for dynamic extension
│   ├── [Bridges etc]  # Additional patterns as applicable
│
├── Program.cs         # Application entry point; pattern demonstration
├── lab3.csproj
└── lab3.sln
```

**Design Principles Applied:**

* **Package by Feature** — Logical separation by pattern implementation.
* **Separation of Concerns** — Each module or class with a single defined role.
* **Interface Usage** — Operations depend on abstractions.
* **Extensibility** — New adapters, decorators, or composites added easily.

---

### 4.2 Design Patterns

This lab demonstrates **three structural design patterns**:

#### Pattern 1: Adapter

**Purpose:** Allows incompatible interfaces to work together.

**Implementation:**
* Adapter classes wrap existing objects and translate their interfaces.
* E.g., adapting a legacy device to be used in a modern system.

**Benefits:**
* Promotes interoperability.
* Encourages reuse of existing components.

#### Pattern 2: Composite

**Purpose:** Compose objects into tree structures to represent part-whole hierarchies.

**Implementation:**
* Define a component interface with composite and leaf classes.
* Recursively process or manipulate complex structures as if they were simple objects.

**Benefits:**
* Simplifies client code.
* Makes working with complex hierarchical structures straightforward.

#### Pattern 3: Decorator

**Purpose:** Add responsibilities to objects dynamically.

**Implementation:**
* Decorator classes wrap components, adding or modifying behavior at runtime.
* E.g., adding logging, validation, or formatting to core operations.

**Benefits:**
* Increases flexibility.
* Avoids subclass explosion.

---

### 4.3 Class Descriptions

#### Component Interfaces

* Abstract interfaces for core elements (e.g., `IDevice`, `IDocumentElement`).
* Define required operations; used throughout adapters, composites, and decorators.

#### Concrete Components

* Leaf implementations of core interfaces.
* Provide standard behavior, e.g., a basic device or document paragraph.

#### Adapter Classes

* Implement or extend core interfaces, internally calling methods on wrapped legacy/foreign objects.

#### Composite Classes

* Maintain lists of child components.
* Support recursive operations (e.g., rendering a document, activating devices).

#### Decorator Classes

* Wrap core components or other decorators.
* Add functionality like logging, authorization, or formatting.

#### Main Program

* Instantiates and demonstrates each pattern with example usage.
* Shows before-and-after effect of applying patterns.

---

## 5. Usage Examples

### Example 1: Adapter Pattern Usage

```csharp
ILegacyDevice legacy = new LegacyPrinter();
IDevice printer = new PrinterAdapter(legacy); // Adapts old interface to IDevice

printer.Print("Hello, world!"); // Uses new interface on legacy object
```

### Example 2: Composite Pattern Usage

```csharp
IDocumentElement header = new TextBlock("Header");
IDocumentElement paragraph = new TextBlock("Some text");
IDocumentElement section = new DocumentSection("Main Section");

section.Add(header);
section.Add(paragraph);

section.Render();
```

### Example 3: Decorator Pattern Usage

```csharp
IDevice basicPrinter = new Printer();
IDevice loggingPrinter = new LoggingDecorator(basicPrinter);

loggingPrinter.Print("Logging this print job!");
```

---

## 6. Results

### 6.1 Program Output Example

```
=== Structural Design Patterns Demo ===

-- Adapter Example --
Using legacy printer via adapter:
[LegacyPrinter] Printing: Hello, world!

-- Composite Example --
Rendering section and its children:
Header
Some text

-- Decorator Example --
[LOG] Printing: Logging this print job!
Printing: Logging this print job!
```

### 6.2 Design Patterns Summary

| Pattern    | Implementation Highlights                | Demonstrated Benefits              |
| ---------- | --------------------------------------- | ---------------------------------- |
| Adapter    | PrinterAdapter adapts legacy to IDevice | Internal interoperability, reuse   |
| Composite  | DocumentSection manages children        | Uniform tree traversal, flexibility|
| Decorator  | LoggingDecorator logs calls             | Flexible runtime extension         |

### 6.3 SOLID Principles Demonstrated

| Principle                    | Implementation Example                                   |
| ---------------------------- | ------------------------------------------------------- |
| **S: Single Responsibility** | Each class addresses a single aspect (adaptation, composition, decoration) |
| **O: Open/Closed**           | New adapters, composites, or decorators can be added without modifying existing code |
| **L: Liskov Substitution**   | All components used via interfaces (`IDevice`, etc.)    |
| **I: Interface Segregation** | Small, focused interfaces                               |
| **D: Dependency Inversion**  | High-level logic depends on abstractions, not concretes |

---

## 7. Conclusions

This lab successfully demonstrates three structural design patterns within a practical domain.

### Key Achievements:

1. **Adapter Pattern** — Allowed legacy objects to integrate seamlessly with modern interfaces.
2. **Composite Pattern** — Enabled simple and complex objects to be managed and used uniformly.
3. **Decorator Pattern** — Provided powerful dynamic extension of behavior with minimal changes.

### Learning Outcomes:

* Gained facility in recognizing and applying structural patterns.
* Improved skills in system architecture by layering and decoupling responsibilities.
* Learned to maximize code reuse, maintainability, and extensibility.

### Practical Benefits:

* **Maintainability:** Decoupled architecture, easier to debug and extend.
* **Extensibility:** New behaviors added with little or no modifications to existing code.
* **Reusability:** Core patterns reusable across domains with similar needs.
* **Testability:** Clean interfaces and separation make components simple to test.

*Suggestions for future development:*

- Add more structural patterns (Facade, Bridge, Proxy, Flyweight)
- Refine composite structure handling with visitor pattern
- Enhance decorators with runtime configuration and chaining
- Integrate unit tests for all patterns
- Create GUI demo for interactive pattern exploration

This lab highlights that structural patterns are essential for scalable, manageable system design.
