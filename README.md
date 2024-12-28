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

You can set up the database using one of the following methods:

* BACPAC file: Import the BACPAC file from [Google Drive link][bacpacGD].
* SQL script: Execute the SQL script from [Google Drive link][sqlScriptGD].
  
After setting up the database, update the connection string in appsettings.json to point to your SQL Server instance:
 ```json
"DefaultConnection": "Server=...;Database=Categories;Trusted_Connection=True;TrustServerCertificate=True"
```

3. **Run the application:**
   
After setting up the database, you can run the application directly without needing to apply migrations.
p.s migrations soon

ᅠ
ᅠ

## ʳᵘsection
1. **Скачайте проект в .zip или клонируйте репозиторий:**
 ```bash
 git clone https://github.com/yourusername/ASPInventory.git
 cd ASPInventory 
```

2. **Настройка базы данных:**
* Используйте [BACPAC файл][bacpacGD] или [SQL скрипт][sqlScriptGD] для создания базы данных.
* Обновите строку подключения в appsettings.json:
```json
"DefaultConnection": "Server=...;Database=Categories;Trusted_Connection=True;TrustServerCertificate=True"
```

3. **Запуск приложения:**

После настройки базы данных приложение можно запустить без применения миграций. p.s миграции будут добавлены

ᅠ
ᅠ

## NuGet packets
- microsoft.aspnetcore.mvc.razor.runtimecompilation
- microsoft.entityframeworkcore
- microsoft.entityframeworkcore.sqlserver
- microsoft.entityframeworkcore.tools

[bacpacGD]: https://drive.google.com/file/d/15RSXp0X61V5kmQVPCXM0IZRecSxl78vZ/view?usp=sharing
[sqlScriptGD]: https://drive.google.com/file/d/1pOu8V6cMt4CJLEHFtuf1pb7CdhUyyMF6/view?usp=sharing
