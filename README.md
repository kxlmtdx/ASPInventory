# ASPInventory

[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)
![License](https://img.shields.io/badge/License-MIT-blue)

## About

ASPInventory is a web application built on the ASP.NET MVC framework, designed for managing and tracking inventory equipment and assets. This project utilizes Microsoft SQL Server as its database backend, providing a robust solution for organizations to maintain an organized inventory system.

## Project Overview

ASPInventory serves as a knowledge base with a user-friendly web interface, allowing users to:

- Track inventory items and their details.
- Manage equipment status and locations.

## Getting Started

To run the ASPInventory project locally, follow these steps:

1. **Clone or download the repository:**
 ```bash
 git clone https://github.com/yourusername/ASPInventory.git
 cd ASPInventory 
```
2. **Set up the database:**

Create a new database with any name.

Replace database name in ApplicationDbContext.cs
```cs
public DbSet<DataSet> YOUR_DB { get; set; }
```
Update the connection string in appsettings.json to point to your SQL Server instance.
```json
"DefaultConnection": "Server=...;Database=...;Trusted_Connection=True;TrustServerCertificate=True"
```

3. **Run the migrations:**

Open the Package Manager Console in Visual Studio.
Run the following command to apply migrations:
```bash
Update-Database
```

## NuGet packets
- microsoft.aspnetcore.mvc.razor.runtimecompilation
- microsoft.entityframeworkcore
- microsoft.entityframeworkcore.sqlserver
- microsoft.entityframeworkcore.tools
