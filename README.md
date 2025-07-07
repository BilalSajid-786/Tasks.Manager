# 🗂️ Tasks Manager

**Tasks Manager** is a role-based task management system that enables streamlined administration of teams, projects, and tasks assigned to employees. Built using ASP.NET Core MVC and Entity Framework Core, the system follows a clean N-Layered architecture promoting separation of concerns and maintainability.

---

## 📌 Key Features

- 🔐 **User authentication and role management** with ASP.NET Core Identity
- 🎯 **Role-based access control** (Admin, Manager, Employee)
- 👥 Manage **teams**, **projects**, and **employee-assigned tasks**
- ✅ Clean multi-layered architecture (SOLID principles)
- 📦 Scalable codebase with strong separation between UI, logic, and data
- 🗄️ SQL Server integration via Entity Framework Core

---

## 🛠️ Tech Stack

| Component            | Technology              |
|----------------------|--------------------------|
| Backend Framework    | ASP.NET Core MVC         |
| User Management      | ASP.NET Core Identity    |
| ORM                  | Entity Framework Core    |
| Database             | SQL Server               |
| Architecture Pattern | N-Layered Architecture   |

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
