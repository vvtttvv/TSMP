# Laboratory Work No.1 (2) - Creational Design Patterns

**Author:** Titerez Vladislav
**Course:** TMPS
**Topic:** Creational Design Patterns

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

The primary objectives of this laboratory work are:

* **Study and understand Creational Design Patterns** – explore patterns that handle object creation mechanisms.
* **Choose a suitable domain** – define main classes, models, and entities for the project.
* **Implement multiple creational patterns** – demonstrate at least three creational design patterns in practice.
* **Apply SOLID principles** – ensure the design follows good software engineering practices.

---

## 2. Theory

### 2.1 What are Creational Design Patterns?

**Creational design patterns** are design patterns that deal with object creation mechanisms, trying to create objects in a manner suitable to the situation. The basic form of object creation could result in design problems or added complexity to the design. Creational design patterns solve this problem by controlling the object creation process.

### 2.2 Types of Creational Patterns

Common creational design patterns include:

* **Singleton** – Ensures a class has only one instance and provides a global access point.
* **Factory Method** – Defines an interface for creating objects but lets subclasses decide which class to instantiate.
* **Abstract Factory** – Provides an interface for creating families of related or dependent objects without specifying their concrete classes.
* **Builder** – Separates the construction of a complex object from its representation, allowing the same construction process to create different representations.
* **Prototype** – Creates new objects by copying an existing object (prototype).
* **Object Pool** – Manages a pool of reusable objects to improve performance.

### 2.3 Why Use Creational Patterns?

* **Flexibility** – Easier to introduce new types without changing existing code.
* **Encapsulation** – Hide the creation logic from the client.
* **Reusability** – Promote code reuse and reduce duplication.
* **Maintainability** – Make the codebase easier to maintain and extend.

---

## 3. Domain Area

**Domain Selected:** Computer Configuration System

This domain involves configuring custom computer systems by selecting compatible hardware components such as processors, GPUs, RAM, and storage. The system allows users to:

* Choose between different setup types (Gaming, Office, Workstation)
* Ensure component compatibility within a family
* Build custom configurations step-by-step
* Get complete system specifications with pricing

**Why This Domain?**

The computer configuration domain naturally demonstrates creational patterns because:

* **Complex object creation** – Computers consist of multiple interdependent components.
* **Product families** – Components come in families (gaming components, office components, etc.).
* **Step-by-step construction** – Systems are built incrementally with optional features.
* **Variation management** – Different configurations require different creation strategies.

---

## 4. Implementation

### 4.1 Project Structure

The project follows a modular architecture with clear separation of concerns:

```
src/main/java/com/example/
│
├── components/              # Component interfaces and implementations
│   ├── processor/          # Processor components
│   │   ├── Processor.java
│   │   ├── GamingProcessor.java
│   │   ├── OfficeProcessor.java
│   │   └── WorkstationProcessor.java
│   ├── gpu/                # GPU components
│   │   ├── GPU.java
│   │   ├── GamingGPU.java
│   │   ├── OfficeGPU.java
│   │   └── WorkstationGPU.java
│   ├── ram/                # RAM components
│   │   ├── RAM.java
│   │   ├── GamingRAM.java
│   │   ├── OfficeRAM.java
│   │   └── WorkstationRAM.java
│   └── storage/            # Storage components
│       ├── Storage.java
│       ├── GamingStorage.java
│       ├── OfficeStorage.java
│       └── WorkstationStorage.java
│
├── domain/                 # Domain models
│   └── model/
│       └── Computer.java   # Main product class
│
├── factory/                # Factory pattern implementations
│   ├── ComponentFactory.java
│   ├── GamingSetupFactory.java
│   ├── OfficeSetupFactory.java
│   └── WorkstationSetupFactory.java
│
├── builder/                # Builder pattern implementations
│   ├── ComputerBuilder.java
│   └── ComputerDirector.java
│
└── Main.java              # Application entry point
```

**Design Principles Applied:**

* **Package by Feature** – Components grouped by their domain responsibility
* **Separation of Concerns** – Each pattern has its dedicated package
* **Single Responsibility** – Each class has one clear purpose
* **Dependency Inversion** – Dependencies on interfaces, not concrete classes

---

### 4.2 Design Patterns

This project implements **three creational design patterns**:

#### Pattern 1: Factory Method

**Purpose:** Defines an interface for creating objects but lets subclasses decide which class to instantiate.

**Implementation:**
* `ComponentFactory` is an abstract class with factory methods (`createProcessor()`, `createGPU()`, etc.)
* Each method returns an interface type, not a concrete class
* Subclasses override these methods to create specific component types

**Benefits:**
* Encapsulates object creation logic
* Allows adding new component types without modifying existing code
* Promotes loose coupling between client code and concrete classes

#### Pattern 2: Abstract Factory

**Purpose:** Provides an interface for creating families of related or dependent objects without specifying their concrete classes.

**Implementation:**
* Three concrete factories: `GamingSetupFactory`, `OfficeSetupFactory`, `WorkstationSetupFactory`
* Each factory creates a complete family of compatible components
* All components from the same factory are guaranteed to work together

**Benefits:**
* Ensures component compatibility within a family
* Makes it easy to switch between product families
* Isolates concrete classes from client code
* Promotes consistency among products

#### Pattern 3: Builder

**Purpose:** Separates the construction of a complex object from its representation, allowing the same construction process to create different representations.

**Implementation:**
* `ComputerBuilder` provides a fluent interface for step-by-step construction
* Supports both required components (processor, GPU, RAM, storage) and optional features (cooling, RGB lighting)
* `ComputerDirector` provides pre-configured build recipes for common scenarios

**Benefits:**
* Controls the construction process step-by-step
* Allows creating different representations using the same construction code
* Provides better control over the construction process
* Makes code more readable with fluent interface

---

### 4.3 Class Descriptions

#### Component Interfaces

**`Processor`, `GPU`, `RAM`, `Storage`**
* Define common interface for all component types
* Each interface declares `getSpecifications()` and `getPrice()` methods
* **SRP:** Each interface is responsible for defining one component type

#### Concrete Components

**`GamingProcessor`, `OfficeProcessor`, `WorkstationProcessor`** (and similar for other components)
* Implement respective component interfaces
* Provide specific specifications and pricing
* **SRP:** Each class represents one specific component variant

#### Computer (Product Class)

**`Computer`**
* Represents the final product being constructed
* Contains all components and optional features
* Provides `getTotalPrice()` method and formatted `toString()` output
* **SRP:** Responsible only for representing a complete computer system

#### Factory Classes

**`ComponentFactory` (Abstract Factory)**
* Declares factory methods for creating all component types
* **OCP:** New factory types can be added without modifying existing factories

**`GamingSetupFactory`, `OfficeSetupFactory`, `WorkstationSetupFactory`**
* Concrete implementations of `ComponentFactory`
* Each creates a compatible family of components
* **SRP:** Each factory is responsible for one product family

#### Builder Classes

**`ComputerBuilder`**
* Provides fluent interface for building `Computer` objects
* Supports method chaining for readable code
* **SRP:** Responsible only for constructing Computer objects

**`ComputerDirector`**
* Encapsulates common build processes
* Provides methods for standard configurations (gaming PC, office PC, workstation)
* **SRP:** Responsible for coordinating the building process

#### Main Application

**`Main`**
* Entry point of the application
* Demonstrates usage of all three patterns
* Creates various computer configurations and displays results

---

## 5. Usage Examples

### Example 1: Creating a Gaming PC with Abstract Factory and Builder

```java
// Create a gaming factory (Abstract Factory pattern)
ComponentFactory gamingFactory = new GamingSetupFactory();

// Use builder and director to construct the PC (Builder pattern)
ComputerDirector director = new ComputerDirector(new ComputerBuilder());
Computer gamingPC = director.constructGamingPC(gamingFactory);

// Display the result
System.out.println(gamingPC);
```

### Example 2: Custom Build with Manual Builder Usage

```java
// Manual step-by-step construction using Builder pattern
Computer customPC = new ComputerBuilder()
    .setName("Custom Mixed Build")
    .setProcessor(new GamingProcessor())      // Factory Method
    .setGPU(new WorkstationGPU())            // Factory Method
    .setRAM(new GamingRAM())                 // Factory Method
    .setStorage(new WorkstationStorage())     // Factory Method
    .setCoolingSystem("Custom Water Cooling")
    .setCaseType("Custom Mod Case")
    .enableRGBLighting()
    .build();

System.out.println(customPC);
```

### Example 3: Creating Multiple Configurations

```java
// Create different factories
ComponentFactory[] factories = {
    new GamingSetupFactory(),
    new OfficeSetupFactory(),
    new WorkstationSetupFactory()
};

// Build different configurations
for (ComponentFactory factory : factories) {
    ComputerDirector director = new ComputerDirector(new ComputerBuilder());
    Computer pc = director.constructGamingPC(factory);
    System.out.println(pc);
}
```

---

## 6. Results

### 6.1 Program Output

When the application runs, it produces the following output:

```
==============================================
COMPUTER SETUP CONFIGURATION SYSTEM
Demonstrating Creational Design Patterns
==============================================

=== Building Gaming PC ===
Creating Gaming Processor...
Creating Gaming GPU...
Creating Gaming RAM...
Creating Gaming Storage...

========================================
COMPUTER CONFIGURATION: Ultimate Gaming Rig
========================================
Processor: Intel Core i9-13900K, 24 cores, 5.8GHz - $589.99
GPU: NVIDIA RTX 4090, 24GB GDDR6X - $1599.99
RAM: 32GB DDR5 6000MHz RGB - $159.99
Storage: 2TB NVMe Gen4 SSD - $199.99
Cooling: Liquid Cooling 360mm
Case: RGB Tempered Glass ATX
RGB Lighting: Enabled
----------------------------------------
TOTAL PRICE: $2549.96
========================================

[... similar output for Office PC and Workstation ...]

=== Custom Build Example ===

========================================
COMPUTER CONFIGURATION: Custom Mixed Build
========================================
Processor: Intel Core i9-13900K, 24 cores, 5.8GHz - $589.99
GPU: NVIDIA RTX A6000, 48GB GDDR6 - $4500.99
RAM: 32GB DDR5 6000MHz RGB - $159.99
Storage: 4TB NVMe Gen4 SSD + 8TB HDD - $699.99
Cooling: Custom Water Cooling
Case: Custom Mod Case
RGB Lighting: Enabled
----------------------------------------
TOTAL PRICE: $5950.96
========================================

==============================================
DESIGN PATTERNS DEMONSTRATED:
1. Factory Method - Component creation methods
2. Abstract Factory - Setup family factories
3. Builder - Computer assembly with fluent API
==============================================
```

### 6.2 Design Patterns Summary

| Pattern           | How It's Implemented                                                                                          | Benefits Demonstrated                                        |
| ----------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------ |
| **Factory Method** | Abstract methods in `ComponentFactory` for creating components                                                | Encapsulation of object creation, flexibility                |
| **Abstract Factory** | Three concrete factories creating compatible component families                                               | Ensures compatibility, easy to add new families              |
| **Builder**        | `ComputerBuilder` with fluent interface and `ComputerDirector` for common configurations                       | Step-by-step construction, readable code, optional features |

### 6.3 SOLID Principles Demonstrated

| Principle                    | Implementation in Project                                                                                                                          |
| ---------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| **S: Single Responsibility** | Each class has one clear responsibility (e.g., `GamingProcessor` only represents a gaming processor)                                               |
| **O: Open/Closed**           | New component types or factories can be added without modifying existing code                                                                      |
| **L: Liskov Substitution**   | All concrete components can be substituted for their interface types without breaking functionality                                                |
| **I: Interface Segregation** | Small, focused interfaces (`Processor`, `GPU`, etc.) instead of one large interface                                                                |
| **D: Dependency Inversion**  | High-level modules (`ComputerBuilder`, `ComputerDirector`) depend on abstractions (`ComponentFactory`, component interfaces), not concrete classes |

---

## 7. Conclusions

This laboratory work successfully demonstrates the implementation and benefits of three creational design patterns in a practical computer configuration system.

### Key Achievements:

1. **Factory Method Pattern** – Successfully encapsulated component creation logic, making it easy to add new component types without modifying existing code.

2. **Abstract Factory Pattern** – Implemented family-based component creation, ensuring that components from the same family (Gaming, Office, Workstation) are compatible with each other.

3. **Builder Pattern** – Created a flexible system for constructing complex `Computer` objects step-by-step, with support for both required and optional components.

### Learning Outcomes:

* **Understanding Pattern Interactions** – Learned how multiple design patterns can work together harmoniously in the same system.
* **Code Organization** – Practiced modular architecture with clear separation of concerns and package-by-feature organization.
* **SOLID Principles** – Applied all five SOLID principles throughout the implementation.
* **Extensibility** – Created a system that is easy to extend with new component types, product families, or build configurations.

### Practical Benefits:

* **Maintainability** – Clean, organized code structure makes maintenance easier.
* **Flexibility** – New features can be added without breaking existing functionality.
* **Reusability** – Components and patterns can be reused in similar contexts.
* **Testability** – Clear dependencies and interfaces make unit testing straightforward.

* Add **Singleton pattern** for configuration management
* Implement **Prototype pattern** for cloning configurations
* Add validation to ensure component compatibility
* Implement persistence layer to save/load configurations
* Create a GUI for interactive computer building

This project demonstrates that creational design patterns are not just theoretical concepts but practical tools that lead to better software design, making code more flexible, maintainable, and extensible.