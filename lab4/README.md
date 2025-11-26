# Laboratory Work No.4 — Behavioral Design Patterns

**Author:** Titerez Vladislav  
**Course:** TMPS  
**Topic:** Behavioral Design Patterns

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

The key objectives of this laboratory work are:

* **Understand and implement Behavioral Design Patterns** — Study core behavioral patterns and their intent.
* **Apply selected patterns to a relevant domain** — Design and implement patterns using practical classes and scenarios.
* **Follow SOLID principles** — Ensure solutions are clean, extensible, and maintainable.

---

## 2. Theory

### 2.1 What are Behavioral Design Patterns?

**Behavioral design patterns** are concerned with algorithms and the assignment of responsibilities between objects. They increase flexibility in carrying out communication.

### 2.2 Types of Behavioral Patterns

Common behavioral patterns include:

* **Strategy** — Defines a family of algorithms, encapsulates each one, and makes them interchangeable.
* **Command** — Encapsulates a request as an object, allowing for parameterization of clients.
* **Observer** — Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified.
* Other patterns: State, Chain of Responsibility, Mediator, Iterator, Template Method, etc.

---

## 3. Domain Area

The project models a **Tower Defense game** scenario, where core gameplay logic and entities are enhanced using behavioral patterns. Key domain elements include Players, Towers, Enemies, and game mechanics such as command execution and event notification.

---

## 4. Implementation

### 4.1 Project Structure

```
lab4/
│
├── Commands/
├── Entities/
├── Observers/
├── Strategies/
├── Game.cs
├── Program.cs
├── TowerDefense.csproj
├── bin/
└── obj/
```

* **Commands/** — Contains implementation of command pattern for actions (e.g. place tower, start wave)
* **Entities/** — Game entities such as Player, Tower, Enemy
* **Observers/** — Observer pattern for event notifications (e.g. tracking health, score)
* **Strategies/** — Various attack or defense strategies

### 4.2 Design Patterns

Patterns used:

* **Command Pattern** (`Commands/`) — To encapsulate user/game actions.
* **Observer Pattern** (`Observers/`) — Used for notifying subsystems or UI about gameplay events.
* **Strategy Pattern** (`Strategies/`) — Used to flexibly switch tower/defense algorithms.

### 4.3 Class Descriptions

- `Game.cs`: Manages main game loop, relies on patterns for extensibility.
- `Program.cs`: Entry point for the application.
- `Commands/`: Contains classes implementing assignment and execution of actions.
- `Entities/`: Defines all core game entities.
- `Observers/`: Classes that subscribe and react to state changes or events.
- `Strategies/`: Various interchangeable gameplay or AI strategies.

---

## 5. Usage Examples

To run the application:

```sh
dotnet run --project lab4/TowerDefense.csproj
```

You can modify strategies, issue commands, or observe events via the program interface.

---

## 6. Results

* Successfully implemented and demonstrated Command, Observer, and Strategy patterns in a Tower Defense game domain.
* The game logic is modular, allowing flexible extensions and adaptation of behaviors at runtime.

---

## 7. Conclusions

This laboratory work deepened understanding of behavioral design patterns by applying them in a practical context. The use of patterns led to a more maintainable and extensible project structure, illustrating their value in real-world software design.

---