# 👨‍💼 Employee Management System (EMS)

A full-featured **Employee Management System** developed using **.NET Framework** with a clean **5-Layer Architecture** and **Entity Framework (EF)** for data access. This system allows administrators to perform CRUD operations on employee records, departments, and other related modules.

---

## 🏗️ Architecture - 5 Layer Structure

This project follows a **5-layer architecture** for maintainability and scalability:


    NTierArchitecture/  
        │
        ├── EMS.Model # POCO entity classes representing database tables
        ├── EMS.Repository # Data access layer using Entity Framework
        ├── EMS.Service # Business logic and service layer  
        ├── EMS.Presentation # UI layer (e.g., Windows Forms or ASP.NET MVC)
        └── EMS.Common # Shared helpers, constants, utility functions


Each layer is independent and follows SOLID principles, allowing easy testing, maintenance, and future scaling.

---

## 🔧 Technologies Used

- ✅ .NET Framework / .NET Core
- ✅ C#
- ✅ Entity Framework (EF)
- ✅ SQL Server
- ✅ Windows Forms / ASP.NET MVC
- ✅ Git for Version Control
- ✅ LINQ

---

## 🧩 Features

- ➕ Add new employees
- 📝 Edit employee information
- 🗑️ Delete employees
- 🔍 Search/filter employees
- 📊 Department and designation management
- 🛡️ Error handling and input validation

---

## 🗃️ Database Design

- Tables: `Employees`, `Departments`, `Designations`, etc.
- Supports Code-First using Entity Framework

---

## 🚀 Getting Started

### 📌 Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (Express, LocalDB, or Full)
- Visual Studio 2022 or later

### 🔧 Setup Instructions

1. **Open the solution in Visual Studio**:
   - Open `EMS.sln`

2. **Set the Startup Project**:
   - Right-click on `EMS.Presentation` → _Set as Startup Project_

3. **Configure Database**:
   - Open `app.config` or `appsettings.json`
   - Replace the connection string with your SQL Server details

4. **Run the Project**:
   - Press `F5` or click the `Start` button in Visual Studio
---

## 🙋‍♂️ Author

**Satyam Kumar**  
📫 [GitHub](https://github.com/SatyamKr002)  
📧 Email: satyam50803@example.com
