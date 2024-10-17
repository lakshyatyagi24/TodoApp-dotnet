
# TodoApp-dotnet

A simple to-do list management application built with **ASP.NET Core**. This app features a RESTful API for backend operations and a clean, responsive frontend interface for managing tasks.

## Features

- **Task Management UI**: Users can create, edit, delete, and mark tasks as completed or not completed.
- **RESTful API**: Exposes endpoints for CRUD operations on tasks.
- **Thread-safe**: Uses `ConcurrentDictionary` to ensure thread-safe operations.
- **Separation of Concerns**: Separate API controllers and view controllers.
- **Environment-Specific Configuration**: Configurable API URL and other settings based on the environment (Development/Production).
- **CORS Enabled**: Allows cross-origin requests for the API.

## Tech Stack

- **Backend**: ASP.NET Core, C#
- **Frontend**: Razor Pages, HTML, CSS, JavaScript
- **Thread-Safe Collection**: `ConcurrentDictionary`
- **Environment Configurations**: `appsettings.Development.json` and `appsettings.Production.json`

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- [Git](https://git-scm.com/)
- A modern browser for the frontend

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/lakshyatyagi24/TodoApp-dotnet.git
   cd TodoApp-dotnet
   ```

2. Install dependencies (if any):

   ```bash
   dotnet restore
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the application in Development mode:

   ```bash
   dotnet run --environment Development
   ```

5. Open a browser and go to `http://localhost:5000` to view the app.

## API Endpoints

| Method | Endpoint             | Description                    |
|--------|----------------------|--------------------------------|
| GET    | `/api/todo`           | Get all tasks                  |
| GET    | `/api/todo/{id}`      | Get a task by ID               |
| POST   | `/api/todo`           | Create a new task              |
| PUT    | `/api/todo/{id}`      | Update an existing task        |
| DELETE | `/api/todo/{id}`      | Delete a task                  |

### Example POST Request

To create a new task, send a `POST` request to `/api/todo` with the following JSON body:

```json
{
  "name": "New Task",
  "isComplete": false
}
```

## Configuration

The app uses environment-specific configuration for settings like the API URL. Make sure to modify the `appsettings.Development.json` and `appsettings.Production.json` files as needed.

### Example `appsettings.Development.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ApiUrl": "http://localhost:5000"
}
```

## Deployment

To deploy this app in a production environment, make sure to:

1. Update the `appsettings.Production.json` with the production API URL and any other production-specific settings.
2. Build and publish the app:

   ```bash
   dotnet publish --configuration Release
   ```

3. Deploy the published files to your web server or cloud hosting provider.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or feedback, please contact [Lakshya Tyagi](mailto:lakshya.tyagi.dav@gmail.com).

## Connect with me

- **Twitter**: [@LakshyaTyagi24](https://x.com/LakshyaTyagi24)
- **LinkedIn**: [Lakshya Tyagi](https://www.linkedin.com/in/lakshyatyagi24/)
- **GitHub**: [LakshyaTyagi24](https://github.com/lakshyatyagi24)

## Acknowledgments

- Special thanks to the [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) team for providing an excellent framework to build web apps.
