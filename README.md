# Shortly — URL Shortener with Analytics

Shortly — лёгкий и расширяемый сервис для сокращения URL с поддержкой статистики и аналитики переходов.

Основные возможности
- Генерация коротких ссылок
- Перенаправление по короткой ссылке
- Сбор статистики: клики, источники, время
- Swagger UI для изучения API (`/docs`)

Технологии
- .NET 10, C# 14
- ASP.NET Core Web API
- EF Core (SQLite по умолчанию)
- Swashbuckle (Swagger)

Быстрый старт (локально)

1. Клонируйте репозиторий:
``` bash
git clone https://github.com/sirz1rael/shortly.git cd shortly
```


2. Настройте строку подключения в `appsettings.Development.json` или через __User Secrets__:
```json
{
"ConnectionStrings": { 
	"DefaultConnection": "Data Source=shortly.db" 
	} 
}
```
3. Запустите миграции базы данных:
``` bash
dotnet ef database update
```

4. Запустите приложение:
```bash
dotnet run --project url_shortener
```

5. Откройте Swagger UI: `https://localhost:5001/docs`

Конфигурация и секреты
- Для локальной разработки используйте __User Secrets__ (`dotnet user-secrets init` / `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=shortly.db"`).
- В продакшне используйте переменные окружения или менеджер секретов (Key Vault).

Тестирование
- Запустите unit и integration тесты:
```bash
dotnet test
```

CI/CD
- CI должен запускать: `dotnet build`, `dotnet test`, `dotnet format --verify-no-changes`.
- Миграции применяются через pipeline, при необходимости — вручную.

Вклад
- Смотрите `CONTRIBUTING.md` для руководства по внесению изменений и открытию PR.

Лицензия
- Укажите лицензию проекта (например, MIT) в `LICENSE`.

Контакты
- Автор: t0kkaaa — nkurakin.cl@gmail.com
