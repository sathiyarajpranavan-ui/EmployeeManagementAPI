# Employee Management API

## Overview

Employee Management API is a RESTful Web API built using ASP.NET Core 8, Entity Framework Core, and SQL Server. The application follows Layered Architecture with Repository Pattern, Dependency Injection, Global Exception Handling, and Input Validation.

## Technology Stack

* ASP.NET Core 8 Web API
* Entity Framework Core
* SQL Server
* Repository Pattern
* Dependency Injection
* FluentValidation
* Global Exception Handling Middleware
* Serilog Logging
* JWT Authentication
* Swagger Documentation

## Features

### Employee Management

* Add Employee
* Get All Employees
* Get Employee By ID
* Update Employee
* Delete Employee

### Authentication

* JWT Token Generation
* Protected APIs using Authorize Attribute

### Validation

* Employee Name Validation
* Email Validation
* Department Validation
* Date of Joining Validation

### Exception Handling

* Global Exception Middleware
* Error Logging using Serilog

## API Endpoints

### Authentication

| Method | Endpoint        | Description        |
| ------ | --------------- | ------------------ |
| POST   | /api/auth/login | Generate JWT Token |

### Employee

| Method | Endpoint           | Description        |
| ------ | ------------------ | ------------------ |
| GET    | /api/employee      | Get Employee List  |
| GET    | /api/employee/{id} | Get Employee By ID |
| POST   | /api/employee      | Add Employee       |
| PUT    | /api/employee      | Update Employee    |
| DELETE | /api/employee/{id} | Delete Employee    |

## Database Setup

Update the connection string in appsettings.json.

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
}


## Run Database Migration

Open Package Manager Console and execute:

Add-Migration InitialCreate

Update-Database

## Run Application

Swagger URL:

https://localhost:5001/swagger


## JWT Authentication

Login using:

--json
{
  "userName": "admin",
  "password": "admin123"
}

Copy the generated JWT token and authorize using Swagger.


## Project Architecture

→ Controllers
→ Dtos
→ Services
→ Repositories
→ Entity Framework Core (DbContext)
→ SQL Server


## Author

Sathiyaraj V

Senior .NET Developer
