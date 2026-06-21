# Cognizant Digital Nurture 5.0 — Deep Skilling Solutions
### DotNet FSE React Track

This repository contains hands-on exercise solutions for the **Cognizant Digital Nurture 5.0 Deep Skilling Program** (DotNet FSE React track).

---

## 📁 Structure

```
cognizant-deepskilling/
└── Week1_DesignPatterns/
    └── Exercise1_SingletonPattern/
        └── SingletonPatternExample/   ← C# Console App (.NET 8)
```

---

## 🗂️ Module 1 — Design Patterns and Principles

### Exercise 1: Implementing the Singleton Pattern

**Scenario:** A logging utility class (`Logger`) must have only one instance throughout the application lifecycle to ensure consistent logging.

**Key Concepts Demonstrated:**
- Private static instance field
- Private constructor (prevents `new Logger()` from outside)
- Public static `GetInstance()` method
- Thread-safe double-checked locking
- Instance equality verification

**How to Run:**
```bash
cd Week1_DesignPatterns/Exercise1_SingletonPattern/SingletonPatternExample
dotnet run
```

**Expected Output:**
```
✅ SUCCESS: logger1 and logger2 are the SAME instance.
   logger1 HashCode: <same value>
   logger2 HashCode: <same value>
```

---

## 🛠️ Tech Stack
- **Language:** C# (.NET 8)
- **IDE:** Visual Studio / Visual Studio Code

---

*Solutions by Rohit Sripathi — DN 5.0 Deep Skilling, 2026*
