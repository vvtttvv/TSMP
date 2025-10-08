# Laboratory No.0 / Titerez Vladislav

## 1. Objective

The goal of this lab is to demonstrate the implementation of **three SOLID principles** in C#:

* **S (Single Responsibility Principle)** – each class should have a single responsibility.
* **O (Open/Closed Principle)** – software entities should be open for extension but closed for modification.
* **D (Dependency Inversion Principle)** – high-level modules should depend on abstractions, not on concrete implementations.

This example uses an **animal creation system** where different animals (`Dog`, `Cat`, `Cow`) can be instantiated and made to produce sounds using a **factory pattern**.

---

## 2. Implementation

### 2.1 Classes

1. **Animal (abstract class)**

   * Holds the common property `Name` for all animals.
   * Declares an abstract method `MakeSound()` to be implemented by each specific animal.
   * **SRP:** This class is responsible only for defining an animal's structure.

2. **Concrete Animals (Dog, Cat, Cow)**

   * Each class inherits from `Animal` and implements the `MakeSound()` method.
   * **SRP:** Each animal class has a single responsibility: producing its unique sound.

3. **IAnimalFactory (interface)**

   * Declares a method `CreateAnimal(string name)`.
   * **DIP:** High-level modules depend on this abstraction instead of concrete animal classes.

4. **Concrete Factories (DogFactory, CatFactory, CowFactory)**

   * Implement `IAnimalFactory` to create specific animal instances.
   * **OCP:** New animals can be added without modifying existing code.

5. **AnimalCreator (high-level module)**

   * Accepts `IAnimalFactory` via constructor (dependency injection).
   * Calls `CreateAnimal()` and `MakeSound()`.
   * **DIP & SRP:** Depends on abstraction and is only responsible for coordinating animal creation and actions.

6. **Program (entry point)**

   * Initializes a list of `AnimalCreator` objects with different factories.
   * Loops over them and calls `CreateAndMakeSound()` with names.

---

### 2.2 Execution Flow

1. `Program.Main()` creates a list of `AnimalCreator` instances using different factories.
2. For each `AnimalCreator`, it calls `CreateAndMakeSound(name)`.
3. `AnimalCreator` calls the factory to create an `Animal` object.
4. The animal's `MakeSound()` method is called, printing its sound to the console.

**Example Output:**

```
Rex says: Woof! 
Mittens says: Meow! 
Bessie says: Moo! 
```

---

## 3. SOLID Principles in the Code

| Principle                    | How It's Implemented                                                                                                                                                               |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **S: Single Responsibility** | Each class has a single responsibility: `Animal` defines the base structure, `Dog/Cat/Cow` define specific sounds, factories create animals, `AnimalCreator` coordinates creation. |
| **O: Open/Closed**           | Adding a new animal requires only creating a new `Animal` subclass and corresponding factory; no existing code needs modification.                                                 |
| **D: Dependency Inversion**  | `AnimalCreator` depends on the `IAnimalFactory` abstraction rather than concrete `Dog`, `Cat`, or `Cow`. This allows flexibility and easy extension.                               |

---

## 4. Result

* Successfully implemented a **factory pattern** for animal creation.
* Demonstrated **three SOLID principles** in a simple console application.
* Output shows that different animals can be created and made to produce sounds dynamically.

---

## 5. Conclusion

This lab successfully illustrates:

* How to **design classes with a single responsibility**.
* How to **extend software without modifying existing code**.
* How to **depend on abstractions instead of concrete implementations** for better flexibility.

The project can be easily extended by adding new animals (e.g., `Lion`) with minimal changes, demonstrating clean and maintainable design following SOLID principles.
