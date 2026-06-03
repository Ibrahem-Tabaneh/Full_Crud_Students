# Education Platform (Back-End API) 🚀

A secure and production-ready RESTful API for an Education Platform, built with **.NET 8** following the principles of **Clean Architecture** and SOLID design patterns.

---

## 📌 Technical Features

* **Clean Architecture Layers:** Strictly decoupled into **Core** (Domain & Application), **Infrastructure** (Data), and **Presentation** (Web API).
* **Secure Authentication:** Implements **JWT Bearer Tokens** with **Refresh Tokens** functionality and secure logout.
* **Advanced Authorization:** * Role-Based Access Control (`[Authorize(Roles = "admin")]`).
  * Custom ownership validation (`User.IsOwnerOrAdmin(id)`) to protect student records.
* **Security & Performance:** * **Rate Limiting** enabled on authentication endpoints to prevent brute-force attacks.
  * **Structured Logging** using `ILogger` to track security events (IP and Email tracking).
* **Data Mapping & Files:** Uses **AutoMapper** for clean DTO mapping, and an asynchronous **File Service** for handling student profile image uploads.

---

## 🛠️ Tech Stack

* **Framework:** .NET 8 Web API
* **ORM:** Entity Framework Core
* **Database:** Microsoft SQL Server
* **Libraries:** AutoMapper, Microsoft.AspNetCore.RateLimiting

---

## 🚀 How to Run the Project

### 1. Database Configuration
Open `appsettings.json` inside the **EducationPlatform.API** project and update the connection string to match your local SQL Server:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EducationPlatformDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

### 2. Apply Migrations
Open the Package Manager Console in Visual Studio and run the following command to generate the database automatically:

Bash
Update-Database

### 3. Run the Application
Set EducationPlatform.API as your Startup Project.

Press F5 or click the Play button.

The Swagger UI page will open automatically at https://localhost:xxxx/swagger so you can test all endpoints.
