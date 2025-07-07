# 🗂️ Tasks Manager

A task management system that enables streamlined administration of teams, projects, and tasks assigned to employees. Built on ASP.NET Core MVC using a clean, maintainable multi-layered architecture.

---

## 📌 Key Features

- Role-based access: Admin, Manager, and Employee
- Manage teams, projects, and employee tasks
- Layered architecture with strong separation of concerns
- Scalable and maintainable codebase
- Uses Entity Framework Core with SQL Server

---

## 🛠️ Tech Stack

| Component        | Technology                     |
|------------------|--------------------------------|
| Backend Framework | ASP.NET Core MVC              |
| ORM              | Entity Framework Core          |
| Database         | SQL Server                     |
| Architecture     | N-Layered (SOLID principles)   |

---

## 🧱 Layered Architecture

This project follows a **clean separation of responsibilities** across the following layers:

### 1. **Presentation Layer**
- MVC controllers and views
- Handles HTTP requests and response rendering

### 2. **ServiceContracts Layer**
- Defines business logic **interfaces**
- Contains **ViewModels** used between presentation and service layers

### 3. **Services Layer**
- Implements logic defined in `ServiceContracts`
- Coordinates data between repositories and the UI
- Contains Mapper to Map from entity to viewmodel and viceversa.

### 4. **RepositoryContracts Layer**
- Defines interfaces for data access

### 5. **Repository Layer**
- Implements repository interfaces
- Direct communication with Entity Framework and the database

### 6. **Entities Layer**
- Contains domain entities and `ApplicationDbContext`
- Defines the data schema and relationships

---
