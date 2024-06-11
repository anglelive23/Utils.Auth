# Utils.Auth

## Overview
`Utils.Auth` is a utility library designed to streamline authentication processes in C# applications. It provides essential components and services to handle user authentication, authorization, and related security tasks.

## Features
- **Utils.Auth**: Endpoints for handling authentication requests and services to handle user authentication, authorization.
- **Utils.Core**: Core logic and domain entities for authentication.
- **Utils.Infrastructure**: Data access and external service integrations.
- **Utils.Auth.API**: Demo Api to demonstrate how to use the library controllers and models.

## Directory Structure

Utils.Auth/

├── Utils.Auth.API/ # API to demonstrate how to use the library controllers and models

├── Utils.Auth/ # Main project containing the core logic

├── Utils.Core/ # Core utility models

└── Utils.Infrastructure/ # Infrastructure services like database access and migrations

## Getting Started
1. **Clone the repository**:
   ```sh
   git clone https://github.com/anglelive23/Utils.Auth.git

Configure settings in appsettings.json.
Build the solution in Visual Studio.

## Usage
Integrate the library into your application by referencing the Utils.Auth project. Implement the necessary interfaces and configure the services in your startup class.

In program.cs add

```csharp
builder.Services.AddInfrastructureServices(builder.Configuration);

- Optionally, you can remove Utils.Auth.API as it demonstrates library usage.

- You can also delete the Infrastructure layer. If you do, replace the AddInfrastructureServices call in Program.cs with this.

```csharp
builder.Services.AddAuthServices<AppDbContext>(configuration);

## Contributing
Contributions are welcome! Please fork the repository and submit pull requests.

## License
This project is licensed under the MIT License.
