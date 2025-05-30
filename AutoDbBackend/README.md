# AutoDbBackend - Entity Framework Core Setup

This project implements Entity Framework Core 8.0 with a clean architecture pattern and MediatR for CQRS.

## Project Structure

- **Api**: Web API layer with controllers and configuration
- **Application**: Application logic, MediatR handlers, and CQRS implementation
- **Domain**: Domain entities and business logic
- **Infrastructure**: Data access layer with Entity Framework

## Entity Framework Core Setup

Entity Framework Core 8.0 has been configured with the following packages:

- `Microsoft.EntityFrameworkCore` (8.0.11)
- `Microsoft.EntityFrameworkCore.SqlServer` (8.0.11)
- `Microsoft.EntityFrameworkCore.Tools` (8.0.11)
- `Microsoft.EntityFrameworkCore.Design` (8.0.11)

## MediatR + Enhanced Result Pattern Implementation

The project uses MediatR for CQRS pattern with an enhanced Result pattern for comprehensive error handling without exceptions.

### Key Components

#### Enhanced Result Pattern

- `Result<T>` - Generic result class for operations that return data
- `Result` - Non-generic result class for operations without return data
- **Features:**
  - `IsSuccess` - Boolean indicating success/failure
  - `Value` - The actual data (for successful operations)
  - `Message` - Custom success or failure message
  - `Errors` - List of detailed error messages
  - `StatusCode` - HTTP status code for proper API responses

#### Result Factory Methods

```csharp
// Success scenarios
Result<Car>.Success(car, "Car created successfully", HttpStatusCode.Created)
Result<Car>.Success(car, "Car retrieved successfully") // Default: 200 OK

// Failure scenarios
Result<Car>.Failure("Validation failed", errors, HttpStatusCode.BadRequest)
Result<Car>.Failure("Single error message") // Default: 400 BadRequest
Result<Car>.NotFound("Car not found") // 404 NotFound
Result<Car>.Unauthorized("Access denied") // 401 Unauthorized
Result<Car>.Forbidden("Insufficient permissions") // 403 Forbidden
```

#### MediatR Setup

- Commands and Queries are handled through MediatR
- No validation behaviors or exception handling (kept minimal)
- Modern .NET 8 conventions with record types
- Extension methods for easy Result to ActionResult conversion

#### Example Usage

**Create Car Command with Validation:**

```csharp
public record CreateCarCommand(string Make, string Model, int Year) : IRequest<Result<Car>>;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<Car>>
{
    public Task<Result<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Make))
            errors.Add("Make is required");

        if (errors.Any())
        {
            return Task.FromResult(Result<Car>.Failure(
                "Validation failed",
                errors,
                HttpStatusCode.BadRequest));
        }

        var car = new Car { /* ... */ };

        return Task.FromResult(Result<Car>.Success(
            car,
            "Car created successfully",
            HttpStatusCode.Created));
    }
}
```

**Controller Integration with Extension Methods:**

```csharp
[HttpPost]
public async Task<ActionResult<Car>> CreateCar(CreateCarCommand command)
{
    var result = await _mediator.Send(command);
    return result.ToActionResult(); // Automatically handles HTTP status codes
}
```

**Response Examples:**

Success Response (201 Created):

```json
{
  "success": true,
  "message": "Car created successfully",
  "data": {
    "id": 123,
    "make": "Toyota",
    "model": "Camry",
    "year": 2023
  }
}
```

Validation Error Response (400 Bad Request):

```json
{
  "success": false,
  "message": "Validation failed",
  "errors": ["Make is required", "Year must be between 1900 and 2025"]
}
```

Not Found Response (404 Not Found):

```json
{
  "success": false,
  "message": "Car with ID 999 was not found",
  "errors": ["Car with ID 999 was not found"]
}
```

### API Endpoints

- `GET /api/cars` - Get all cars
- `GET /api/cars/{id}` - Get car by ID
- `POST /api/cars` - Create a new car

Example POST request body:

```json
{
  "make": "Toyota",
  "model": "Camry",
  "year": 2023
}
```

### Result Extension Methods

The `ResultExtensions` class provides convenient methods to convert Result objects to ActionResult:

```csharp
// For Result<T>
return result.ToActionResult();

// Automatically handles:
// - HTTP status codes from Result.StatusCode
// - Success/error response formatting
// - Proper JSON structure
```

## Database Scaffolding

To scaffold your existing database into entity classes, follow these steps:

### 1. Update Connection String

First, update the connection string in `Api/appsettings.json` and `Api/appsettings.Development.json` to point to your existing database:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

For SQL Server Authentication, use:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}
```

### 2. Scaffold Database

Run the following command from the solution root directory to scaffold your database:

```bash
dotnet ef dbcontext scaffold "YOUR_CONNECTION_STRING" Microsoft.EntityFrameworkCore.SqlServer \
  --project Infrastructure \
  --startup-project Api \
  --context-dir Data/Context \
  --output-dir ../Domain/Entities \
  --context ApplicationDbContext \
  --force
```

**Example with LocalDB:**

```bash
dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=true;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer \
  --project Infrastructure \
  --startup-project Api \
  --context-dir Data/Context \
  --output-dir ../Domain/Entities \
  --context ApplicationDbContext \
  --force
```

### 3. Command Explanation

- `--project Infrastructure`: Specifies the project where the DbContext will be created
- `--startup-project Api`: Specifies the startup project (needed for configuration)
- `--context-dir Data/Context`: Directory for the DbContext (relative to Infrastructure project)
- `--output-dir ../Domain/Entities`: Directory for entity classes (relative to Infrastructure project, pointing to Domain/Entities)
- `--context ApplicationDbContext`: Name of the DbContext class
- `--force`: Overwrites existing files

### 4. Post-Scaffolding Steps

After scaffolding, you may need to:

1. **Move entity configurations**: If you want to separate entity configurations, create configuration classes in `Infrastructure/Data/Configurations/`

2. **Update the DbContext**: The scaffolded context will replace the base one. You may want to merge the configurations.

3. **Add repositories**: Create repository interfaces in the Application layer and implementations in the Infrastructure layer.

4. **Update dependency injection**: Add any additional services to `Infrastructure/DependencyInjection.cs`

### 5. Alternative: Scaffold to Specific Tables

To scaffold only specific tables:

```bash
dotnet ef dbcontext scaffold "YOUR_CONNECTION_STRING" Microsoft.EntityFrameworkCore.SqlServer \
  --project Infrastructure \
  --startup-project Api \
  --context-dir Data/Context \
  --output-dir ../Domain/Entities \
  --context ApplicationDbContext \
  --table Table1 --table Table2 \
  --force
```

### 6. Update Existing Database

If you need to update the scaffolded entities after database changes:

```bash
dotnet ef dbcontext scaffold "YOUR_CONNECTION_STRING" Microsoft.EntityFrameworkCore.SqlServer \
  --project Infrastructure \
  --startup-project Api \
  --context-dir Data/Context \
  --output-dir ../Domain/Entities \
  --context ApplicationDbContext \
  --force
```

## Building and Running

```bash
# Restore packages
dotnet restore

# Build solution
dotnet build

# Run the API
dotnet run --project Api
```

## Notes

- The connection string is currently set to use your SQL Server instance. Update it to match your database server.
- Entity classes will be generated in the `Domain/Entities` folder following clean architecture principles.
- The DbContext will be created in `Infrastructure/Data/Context/ApplicationDbContext.cs`
- All Entity Framework services are registered in the `Infrastructure/DependencyInjection.cs` file.
- MediatR is configured for CQRS pattern with enhanced Result pattern for comprehensive error handling without exceptions.
- The Result pattern includes custom messages, detailed errors, and HTTP status codes for proper API responses.
