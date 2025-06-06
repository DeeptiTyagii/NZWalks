# **NZWalks API**

**NZWalks API** is a backend Web API Project built to manage walking trails in different regions of New Zealand. It provides secure and organized endpoints for **user authentication**, **region management**, **walk management**, and **image uploads**.

## **Technologies Used**

- **C#**: The primary programming language used to build the application.
- **ASP.NET Core Web API (.NET 8)**: A modern, cross-platform framework for building RESTful APIs.
- **Entity Framework Core**: An ORM used to interact with **SQL Server**.
- **SQL Server**: Stores data related to users, regions, walks, and images.
- **Authentication & Authorization**: Implemented using **Microsoft Identity** and **JWT tokens**.
- **AutoMapper**: For mapping between domain models and DTOs.
- **Microsoft.AspNetCore.Mvc**: Used for building controllers and handling HTTP requests.
- **Microsoft.Extensions.Logging**: Logging using the built-in `ILogger` interface.
- **IWebHostEnvironment**: For accessing environment-specific file paths.
- **IHttpContextAccessor**: For accessing the base URL and HTTP context.

## **API Endpoints**

### **AuthController**
- `POST /api/Auth/Register`: Register a new user.
- `POST /api/Auth/Login`: Log in and receive a JWT token.

### **RegionController**
- `GET /api/Region`
- `GET /api/Region/{id}`
- `POST /api/Region`
- `PUT /api/Region/{id}`
- `DELETE /api/Region/{id}`

### **WalkController**
- `GET /api/Walk`
- `GET /api/Walk/{id}`
- `POST /api/Walk`
- `PUT /api/Walk/{id}`
- `DELETE /api/Walk/{id}`

### **ImageController**
- `POST /api/Image/Upload`: Upload an image for a walk.
