# **NZWalks API**

**NZWalks API** is a backend API Project built to manage walks in different regions of New Zealand. It provides endpoints for user authentication, region management, walk management, and image upload for walks.

---

## **Technologies Used**

- **C#**: The primary programming language used.
- **ASP.NET Core Web API**: The API is built using ASP.NET Core framework, which provides a powerful and flexible platform for building web applications and APIs.
- **Entity Framework Core**: Entity Framework Core is used as the Object-Relational Mapping (ORM) tool to interact with the database.
- **SQL Server**: The database used to store walk and user data.
- **Microsoft Identity**: The API uses Microsoft Identity for user authentication and role-based authorization.
- **Authentication and Authorization**: Handled using Microsoft Identity with JWT tokens and role-based access.
- **AutoMapper**: AutoMapper is used for object-to-object mapping between domain models and DTOs.
- **Microsoft.AspNetCore.Mvc**: The API uses ASP.NET Core's MVC framework for handling HTTP requests and responses.
- **Microsoft.Extensions.Logging**: Logging is done using the ILogger interface provided by ASP.NET Core.
- **IWebHostEnvironment**: It is used to get the web host environment information, such as content root path.
- **IHttpContextAccessor**: IHttpContextAccessor is used to access the HttpContext, which is used for getting the base URL to form image file paths.
- **.NET 8**: The API is built using the latest version of the .NET platform.

---

## **API Endpoints**

### **AuthController**

- `POST /api/Auth/Register`: Register a new user with the provided username, email, and password. Optionally, roles can be assigned to the user during registration.
- `POST /api/Auth/Login`: Authenticate a user with their email and password and return a JWT token for further API access.

### **RegionController**

- `GET /api/Region`: Get a list of all regions.
- `GET /api/Region/{id}`: Get a specific region by its ID.
- `POST /api/Region`: Create a new region with the provided region data.
- `PUT /api/Region/{id}`: Update an existing region with the provided region data.
- `DELETE /api/Region/{id}`: Delete a region by its ID.

### **WalkController**

- `GET /api/Walk`: Get a list of walks with optional filters and pagination.
- `GET /api/Walk/{id}`: Get a specific walk by its ID.
- `POST /api/Walk`: Create a new walk with the provided walk data.
- `PUT /api/Walk/{id}`: Update an existing walk with the provided walk data.
- `DELETE /api/Walk/{id}`: Delete a walk by its ID.

