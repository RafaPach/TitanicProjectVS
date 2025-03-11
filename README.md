# 🚀 Developer Pathways - Titanic API (.NET, CQRS, Clean Architecture)

This a learning-driven project where I continuously explore and implement modern software development concepts and best practices in **.NET**.

This API project focuses on providing data insights from the famous **Titanic dataset**. It's a playground for practicing **Clean Architecture**, **CQRS**, **MediatR**, **Entity Framework Core**, and more, following **best practices** and continuously evolving through **pull requests** and **community feedback**.

---

## 📝 Project Overview

The primary objective of this project is to **master backend development** in a way that embraces **real-world architectural patterns** and builds a foundation for scalable, maintainable, and testable applications. Along the way, I am continuously **challenging myself** and **adopting feedback** to refine the solution.

### 💡 How It Started
- I initially began this project as a **simple ASP.NET Core API** in **VS Code**, focusing on basic CRUD operations and LINQ queries against the Titanic dataset.
- As I progressed, I recognized the need for a **more structured approach**, leading me to move the project into **Visual Studio** and refactor it using **Clean Architecture principles**.

### 🚀 How It’s Going
- After receiving **continuous feedback** from mentors, I began integrating **CQRS** with **MediatR** to clearly separate read and write operations. This was a significant shift in mindset, but I quickly saw how it led to **cleaner code**, **better scalability**, and **easier testing**.
- I also introduced **Domain-Driven Design (DDD)** concepts to better model the business logic and ensure that the code aligns with the domain language.
- Each improvement has been made incrementally, often driven by **pull requests**, **peer reviews**, and my own research into **best practices** and **software design patterns**.

---

The goal of this project is to **master** backend development by:

- Building a clean, maintainable **RESTful API** using **ASP.NET Core**.
- Practicing **CQRS (Command Query Responsibility Segregation)** with **MediatR**.
- Implementing **Domain-Driven Design (DDD)** patterns.
- Learning **Clean Architecture** structure for scalability and separation of concerns.
-  Continuously **improve** through feedback, code reviews, and pull requests.

This project is part of my **Developer Pathways** journey, where I document my progress and implement modern backend practices while learning through code reviews and PRs.

---

## ⚙️ Tech Stack

| Technology              | Purpose                               |
|-------------------------|---------------------------------------|
| **.NET 8**              | Backend framework                    |
| **ASP.NET Core**        | Web API framework                    |
| **Entity Framework Core** | ORM for data access                |
| **MediatR**             | CQRS pattern / in-process messaging  |
| **Clean Architecture**  | Project structure and separation     |
| **SQL Server**          | Database                             |
| **Swagger**             | API documentation                    |


---

## ✅ Current Features

- Get passengers **grouped by class** with aggregated stats.
- Get **survival rates** by gender.
- Cleanly separated **queries** using **CQRS & MediatR**.
- Use of **extension methods** for mapping domain models to DTOs.
- Fully **async** data access using EF Core.

---

## 🛠️ How To Run Locally

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server / SQLite (or use in-memory DB for testing)
- Optional: Postman, Swagger UI for API testing

### Steps

1. Clone the repo:
    ```bash
    git clone https://github.com/yourusername/developer-pathways-titanic.git
    cd developer-pathways-titanic
    ```

2. Update the connection string in `appsettings.json` (or use In-Memory DB for testing).

3. Run the project:
    ```bash
    dotnet run
    ```

4. Test endpoints at:
    ```
    https://localhost:{port}/api/passenger-class
    https://localhost:{port}/api/passenger-survival/survival-rates
    ```

---

## 🚀 What's Next?

I’m constantly **learning** and **improving** this project!  
Planned improvements:

- ✅ Add **Command Handlers** (Create/Update/Delete operations).
- ✅ Introduce **Validation** using FluentValidation.
- ✅ Refactor into **Domain Layer** (DDD).
- ✅ Add **Authentication & Authorization** (JWT).
- ✅ Optimize **EF Core Queries** for performance.
- ✅ Implement **Logging** and **Error Handling Middleware**.
- ✅ Explore **Repository + Unit of Work** pattern (as needed).

---
