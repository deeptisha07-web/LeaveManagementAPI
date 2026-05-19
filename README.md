# Employee Leave Management API

A REST API built with ASP.NET Core 9 for managing employee leave requests with JWT authentication and role-based access control.

## Features
- JWT Authentication — secure login with token based access
- Role-based access control — Admin and Employee roles
- Leave application and approval workflow
- Swagger UI for API documentation and testing
- Clean project structure with Services and DTOs

## Tech Stack
- ASP.NET Core 9
- Entity Framework Core 9
- SQL Server
- JWT Bearer Authentication
- Swashbuckle Swagger

## Project Structure
~~~
LeaveManagementAPI/
├── Controllers/    — API endpoints
├── Services/       — Business logic
├── Models/         — Database models
├── DTOs/           — Request/response objects
├── Data/           — Database context
~~~

## API Endpoints

### Auth
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/Auth/register | Register new user |
| POST | /api/Auth/login | Login and get JWT token |

### Leave
| Method | Endpoint | Description | Role |
|--------|----------|-------------|------|
| POST | /api/Leave/apply | Apply for leave | Employee |
| GET | /api/Leave/my-leaves | View own leaves | Employee |
| GET | /api/Leave/all-leaves | View all leaves | Admin |
| PUT | /api/Leave/update-status/{id} | Approve or reject leave | Admin |

## How to Run
1. Clone this repository
2. Open in Visual Studio 2022
3. Update connection string in appsettings.json
4. Run this in Package Manager Console: Update-Database
5. Press F5 — Swagger opens automatically at /swagger

## Testing the API
1. Register a user via POST /api/Auth/register
2. Login via POST /api/Auth/login — copy the token
3. Click Authorize in Swagger — enter: Bearer {your token}
4. Now test all protected endpoints
