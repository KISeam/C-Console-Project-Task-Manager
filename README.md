# CSharp-Console-Project-Task-Manager

A console-based C# application developed using .NET 10.0 and Entity Framework Core.
This project is a database-driven task management system that demonstrates CRUD operations, LINQ queries, persistent data storage, and clean console application architecture.

---

## 📌 Project Overview

This application provides a fully interactive task management system with a menu-driven interface.
Users can create, view, update, and delete tasks while storing all data persistently using SQLite database integration.

### Features:

* Add new tasks
* View all tasks
* Filter pending tasks using LINQ
* Filter completed tasks using LINQ
* Mark tasks as completed
* Delete tasks
* Persistent database storage using SQLite
* Automatic database creation using Entity Framework Core

---

## 🧠 Key Concepts Demonstrated

* Object-Oriented Programming (OOP)
* Classes and Objects
* Entity Framework Core
* SQLite Database Integration
* CRUD Operations
* LINQ Query Filtering
* DbContext and DbSet
* Input validation using `TryParse`
* Menu-driven console application design
* Data persistence with relational database

---

## 🛠 Technologies Used

* C#
* .NET 10.0 SDK
* Entity Framework Core
* SQLite
* LINQ

---

## 📂 Project Structure

```bash
C-Console-Project-Task-Manager/
│── Program.cs
│── TodoTask.cs
│── AppDbContext.cs
│── tasks.db (auto-generated)
│── C-Console-Project-Task-Manager.csproj
│── README.md
```

---

## ▶️ How to Run

### Clone the Repository

```bash
git clone <your-repository-url>
```

### Navigate to Project Folder

```bash
cd C-Console-Project-Task-Manager
```

### Restore Dependencies

```bash
dotnet restore
```

### Run the Application

```bash
dotnet run
```

---

## 💻 Sample Output

```text
========================================
    WELCOME TO DATABASE TASK MANAGER
========================================

--- Main Menu ---
1. Add New Task
2. View All Tasks
3. View Pending Tasks Only (LINQ)
4. View Completed Tasks Only (LINQ)
5. Mark Task as Completed
6. Delete a Task
0. Exit Application

Enter choice: 1

Enter task title: Learn Entity Framework Core

Task added successfully to database!
```

---

## 🗄 Database System

The application automatically:

* Creates SQLite database (`tasks.db`)
* Stores all tasks persistently
* Tracks task completion status
* Saves task creation timestamps
* Uses Entity Framework Core migrations and database context management

---

## 🔍 LINQ Filtering System

The project demonstrates LINQ-based filtering:

### Pending Tasks

```csharp
query = query.Where(t => !t.IsCompleted);
```

### Completed Tasks

```csharp
query = query.Where(t => t.IsCompleted);
```

This allows efficient task filtering directly from the database.

---

## 🎯 Learning Objectives

* Building database-driven console applications
* Understanding Entity Framework Core workflow
* Implementing CRUD operations in C#
* Using SQLite with .NET applications
* Writing LINQ queries for filtering data
* Structuring scalable console applications
* Managing persistent application data

---

## 👨‍💻 Author

Seam
Full-stack Developer

---
