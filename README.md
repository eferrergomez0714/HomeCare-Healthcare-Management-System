# HomeCare Healthcare Management System

A full-stack healthcare management system built with **C#, ASP.NET Core Web API, Entity Framework Core, SQL Server, Angular, and Azure Blob Storage**.

The project is composed of three applications that work together to manage patients, caregivers, and medical records.

---

## 📌 Project Overview

The HomeCare Healthcare Management System provides a backend API, Angular frontend, and separate medical records API for storing medical documents in Azure Blob Storage.

The system demonstrates practical experience with:

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Angular
- TypeScript
- REST APIs
- LINQ
- Dependency Injection
- Repository Pattern
- DTOs
- Object Mapping
- Data Validation
- Relational Database Design
- Azure Blob Storage
- Git/GitHub

---

## 🏗️ System Architecture

```text
                    ┌───────────────────────┐
                    │   Angular Frontend    │
                    │   HomeCare Frontend   │
                    └───────────┬───────────┘
                                │
                                │ HTTP / REST
                                ▼
                    ┌───────────────────────┐
                    │ ASP.NET Core Web API  │
                    │    HomeCare Backend   │
                    └───────────┬───────────┘
                                │
                                │ Entity Framework Core
                                ▼
                    ┌───────────────────────┐
                    │      SQL Server       │
                    │      HomeCareDB       │
                    └───────────────────────┘


                    ┌───────────────────────┐
                    │ Medical Records API   │
                    │   ASP.NET Core API    │
                    └───────────┬───────────┘
                                │
                                │ Azure Blob SDK
                                ▼
                    ┌───────────────────────┐
                    │   Azure Blob Storage  │
                    │    Medical Records    │
                    └───────────────────────┘
```

---

# 📂 Project Structure

The repository contains three separate applications:

```text
HomeCare-Healthcare-Management-System/
│
├── HomeCare-Backend/
│   ├── Controllers/
│   ├── Data/
│   ├── Dtos/
│   ├── Interfaces/
│   ├── Mappers/
│   ├── Migrations/
│   ├── Models/
│   ├── Repository/
│   ├── Services/
│   ├── Program.cs
│   └── HomeCare.csproj
│
├── HomeCare-Frontend/
│   ├── public/
│   ├── src/
│   ├── angular.json
│   ├── package.json
│   └── tsconfig.json
│
├── Medical-Records-API/
│   ├── Controllers/
│   ├── Interfaces/
│   ├── Models/
│   ├── Properties/
│   ├── Services/
│   ├── Program.cs
│   └── ClinicalHistory.csproj
│
├── .gitignore
└── README.md
```

---

# 🔧 Technologies

## Backend

- C#
- .NET
- ASP.NET Core Web API
- Entity Framework Core
- LINQ
- REST APIs
- Dependency Injection
- Repository Pattern
- DTOs
- Object Mapping
- Data Validation

## Database

- Microsoft SQL Server
- Entity Framework Core Migrations
- Relational Database Design

## Frontend

- Angular
- TypeScript
- HTML
- CSS
- JavaScript
- Angular Services
- Angular Components
- Angular HTTP Client

## Cloud

- Microsoft Azure
- Azure Blob Storage

## Development Tools

- Visual Studio
- Visual Studio Code
- Git
- GitHub
- Postman
- PowerShell

---

# 🏥 HomeCare Backend

The HomeCare Backend is an ASP.NET Core Web API responsible for managing patients, caregivers, and their relationships.

## Backend Features

The API provides functionality for:

- Creating patients
- Retrieving patients
- Updating patient information
- Deleting patients
- Searching patients by name
- Searching patients by age
- Managing caregivers
- Managing patient-caregiver relationships
- Input validation
- Database persistence through Entity Framework Core
- RESTful API endpoints

---

# 🗄️ Database Design

The backend uses **Microsoft SQL Server** with Entity Framework Core.

The main entities include:

```text
Patients
CareGivers
PatientCareGiver
```

The `PatientCareGiver` table represents the relationship between patients and caregivers.

The relationship is configured as a many-to-many relationship using a composite key.

```text
Patient
   │
   │
   │ 1
   │
   ▼
PatientCareGiver
   ▲
   │
   │ 1
   │
CareGiver
```

Entity Framework Core is responsible for:

- Mapping C# models to database tables
- Managing relationships
- Generating SQL queries
- Tracking entities
- Database migrations
- Persisting application changes

---

# 🧱 Backend Architecture

The backend follows a layered structure to separate responsibilities.

```text
Controllers
     │
     ▼
Repositories / Data Access
     │
     ▼
Entity Framework Core
     │
     ▼
SQL Server
```

The project also uses:

- Interfaces
- DTOs
- Mappers
- Dependency Injection
- Repository Pattern
- Entity Framework Core

This structure helps keep API controllers focused on handling HTTP requests while data-access logic remains separated.

---

# 📦 Repository Pattern

The backend uses the Repository Pattern to separate data-access operations from the API controllers.

Examples include repositories for:

- Patients
- Caregivers
- Patient-caregiver relationships

Repositories provide methods for interacting with the database through Entity Framework Core.

Dependency Injection is used to register and provide these repositories to the application.

Example concept:

```csharp
builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();
```

This allows controllers to depend on interfaces rather than directly creating repository objects.

---

# 🔄 DTOs and Object Mapping

The API uses Data Transfer Objects (DTOs) to separate API request/response models from database entities.

DTOs are used to:

- Control the data exposed through the API
- Define request models
- Define response models
- Reduce unnecessary coupling between API models and database entities

Mapping logic is separated into mapper classes.

---

# ✅ Data Validation

The HomeCare API includes validation for patient information such as:

- Name
- Email
- Age
- City

Invalid input can be rejected by the API with appropriate validation responses.

This helps prevent invalid data from being stored in the database.

---

# 🔎 Patient Search

The backend supports searching patients using query parameters.

Examples include searching by:

```text
Patient Name
Patient Age
```

LINQ and Entity Framework Core are used to filter patient records.

Conceptually:

```csharp
patients.Where(p => p.Name.Contains(searchName))
```

The resulting query is translated by Entity Framework Core into SQL that is executed against SQL Server.

---

# 🌐 HomeCare Frontend

The HomeCare Frontend is an Angular application that communicates with the ASP.NET Core backend through HTTP requests.

## Frontend Features

The Angular application includes functionality for:

- Displaying patients
- Creating patients
- Updating patient information
- Deleting patients
- Searching patients by name
- Searching patients by age
- Displaying patient information
- Communicating with REST APIs
- Form input handling

---

# 🧩 Angular Structure

The frontend uses Angular components and services.

A simplified structure is:

```text
Angular Application
│
├── Components
│   └── Patients
│
├── Services
│   └── PatientService
│
├── Models
│   └── Patient Models
│
└── API Communication
    └── ASP.NET Core Web API
```

Angular services are responsible for communicating with the backend API.

Components are responsible for displaying and interacting with the data.

---

# 🔌 API Communication

The Angular frontend communicates with the ASP.NET Core backend using HTTP requests.

The application uses operations such as:

```text
GET
POST
UPDATE
DELETE
```

The Angular application sends requests to the HomeCare API and receives JSON responses.

CORS is configured in the ASP.NET Core application to allow the Angular development application to communicate with the backend.

---

# 🩺 Medical Records API

The Medical Records API is a separate ASP.NET Core Web API responsible for handling medical records.

Instead of storing medical documents directly in the SQL Server database, the application uses **Azure Blob Storage**.

The API provides functionality for working with medical record files stored in an Azure Blob Storage container.

---

# ☁️ Azure Blob Storage

The Medical Records API uses the Azure Blob Storage SDK to communicate with Azure Storage.

The application uses:

```text
ASP.NET Core API
       │
       ▼
BlobStorageService
       │
       ▼
Azure Blob Storage
       │
       ▼
Medical Records Container
```

The storage service is responsible for communicating with the Azure Blob Storage container.

This demonstrates how an ASP.NET Core application can integrate with cloud-based object storage.

---

# 🔐 Configuration and Security

Sensitive configuration values should **not** be committed to GitHub.

Examples include:

- Azure Storage Account Keys
- Passwords
- API keys
- Connection strings containing credentials
- Other secrets

Local development configuration should be stored using appropriate mechanisms such as:

- User Secrets
- Environment variables
- Local development configuration

The public repository should contain only safe configuration or placeholder values.

For example:

```json
{
  "AzureStorage": {
    "AccountName": "YOUR_ACCOUNT_NAME",
    "AccountKey": "YOUR_ACCOUNT_KEY",
    "ContainerName": "medical-records"
  }
}
```

Do not commit real Azure credentials to the repository.

---

# 📋 Prerequisites

To run this project locally, install the following:

- .NET SDK
- Visual Studio or Visual Studio Code
- SQL Server
- SQL Server Management Studio or another SQL Server management tool
- Node.js
- npm
- Angular CLI
- Git
- Azure Storage account for the Medical Records API

---

# 🚀 Getting Started

## 1. Clone the Repository

```bash
git clone https://github.com/YOUR-GITHUB-USERNAME/HomeCare-Healthcare-Management-System.git
```

Navigate into the project:

```bash
cd HomeCare-Healthcare-Management-System
```

---

# 🖥️ Running the HomeCare Backend

Navigate to the backend project:

```bash
cd HomeCare-Backend
```

Restore the .NET dependencies:

```bash
dotnet restore
```

Update the SQL Server connection string in:

```text
appsettings.json
```

Then apply the Entity Framework Core migrations:

```bash
dotnet ef database update
```

Run the API:

```bash
dotnet run
```

The API will start using the configured ASP.NET Core development URL.

---

# 🌐 Running the Angular Frontend

Open a new terminal and navigate to:

```bash
cd HomeCare-Frontend
```

Install the Angular dependencies:

```bash
npm install
```

Start the Angular development server:

```bash
ng serve
```

The Angular application can then be accessed through the local development URL provided by Angular.

---

# ☁️ Running the Medical Records API

Navigate to:

```bash
cd Medical-Records-API
```

Restore dependencies:

```bash
dotnet restore
```

Configure the Azure Storage settings using local development configuration.

Run the API:

```bash
dotnet run
```

The Medical Records API will communicate with the configured Azure Blob Storage account.

---

# 🧪 API Testing

The APIs can be tested using tools such as:

- Postman
- Swagger
- `.http` files included with the ASP.NET Core projects

Example API operations include:

```text
GET    /patients
POST   /patients
PUT    /patients/{id}
DELETE /patients/{id}
```

The exact endpoints may vary depending on the controller implementation.

---

# 🧠 Development Concepts Demonstrated

This project demonstrates practical understanding of several software development concepts.

### Object-Oriented Programming

The backend is developed using C# and object-oriented programming principles.

### Dependency Injection

ASP.NET Core Dependency Injection is used to register repositories and services and provide them to controllers and other classes.

### Repository Pattern

Data-access logic is separated from controllers through repository interfaces and implementations.

### Entity Framework Core

EF Core is used as the ORM for interacting with SQL Server.

### LINQ

LINQ is used for querying and filtering patient data.

### DTOs

DTOs are used to control API request and response models.

### Relational Database Design

The application uses relational entities and relationships, including a many-to-many patient-caregiver relationship.

### REST APIs

The backend exposes HTTP endpoints for application functionality.

### Angular

The frontend demonstrates component-based development and service-based API communication.

### Cloud Storage

The Medical Records API demonstrates integration with Azure Blob Storage.

---

# 🔮 Future Improvements

Potential future improvements include:

- Authentication and authorization
- Role-based access control
- Improved frontend UI/UX
- Expanded caregiver management functionality
- Additional medical record management features
- Automated unit and integration testing
- Production deployment
- Improved logging and monitoring
- Additional API documentation

---

# 📚 What I Learned

Through this project, I gained hands-on experience building a full-stack application using modern Microsoft development technologies.

The project provided practical experience with:

- Designing RESTful APIs
- Building ASP.NET Core applications
- Working with Entity Framework Core
- Designing relational databases
- Implementing repository-based data access
- Using dependency injection
- Creating and consuming DTOs
- Implementing API validation
- Building Angular components and services
- Connecting Angular to ASP.NET Core APIs
- Working with Azure Blob Storage
- Managing application configuration
- Using Git and GitHub for source control

---

# 👨‍💻 Author

**Ernesto Ferrer**

Computer Science Graduate  
Backend C#/.NET Developer | Full Stack Developer

### Technical Focus

```text
C#
.NET
ASP.NET Core
Entity Framework Core
SQL Server
Angular
TypeScript
REST APIs
LINQ
Azure
Git
```

---