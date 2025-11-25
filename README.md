# Shortly — URL Shortener with Analytics

Shortly is a lightweight and extensible URL shortening service with built-in click statistics and analytics.

## 🚀 Key Features
- **Short URL Generation** - Convert long URLs into short, shareable links
- **Smart Redirection** - Fast and reliable redirects via short codes
- **Click Analytics** - Track clicks, referral sources, and timestamps
- **API Documentation** - Interactive Swagger UI available at `/docs`

## 🛠 Tech Stack
- .NET 10 with C# 14
- ASP.NET Core Web API
- Entity Framework Core (SQLite default)
- Swashbuckle for Swagger/OpenAPI

## ⚡ Quick Start (Local Development)

### 1. Clone the Repository
```pwsh
git clone https://github.com/sirz1rael/shortly.git
cd shortly
```
### 2. Configure Database Connection
Add your connection string in appsettings.Development.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=shortly.db"
  }
}
```
Or use **User Secrets** for better security:
```pwsh
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=shortly.db"
```

### 3. Run Database Migrations
```pwsh
dotnet ef database update
```

### 4. Run the Application
```pwsh
dotnet run --project url_shortener
```

### 5. Explore the API
Open Swagger UI in your browser at `http://localhost:5001/docs`.

## 🔧 Configuration & Security
### Local Development
- Use **User Secrets** or `.env` files to manage sensitive data.
- Optional: Create .env files for environment-specific settings.
- Never commit secrets or connection strings

### Production
- Use enviroment variables or secure secret management solutions.
- Secure secret management (Azure Key Vault, AWS Secrets Manager) is recommended for production.
- Proper CORS configuration is essential to avoid security risks.

## 🧪 Testing
Run the test suite to verify everything works:
```pwsh
dotnet test
```

## 🔄 CI/CD Pipeline
- **Continuous Integration:** Runs on every PR
    - `dotnet build`
    - `dotnet test`
    - `dotnet format --verify-no-changes`
    - Static code analysis
- **Continuous Deployment:** Deploys to production after successful tests and reviews.
- Database migrations applied via pipeline

## 🤝 Contributing
We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.
- Code style standarts
- Pull Request process
- Testing requirements
- Commit message conventions

## 📄 License
This project is licensed under the GNU General Public License v3.0. See the [LICENSE](LICENSE) file for details.

## 📞 Contact
**Author:** t0kkaaa
**Email:** nkurakin.cl@gmail.com
**Github:** [sirz1rael](https://github.com/sirz1rael)
