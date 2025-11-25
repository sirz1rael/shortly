using url_shortener.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using url_shortener.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Shortly API",
        Version = "v1",
        Description = "API for shortening URLs with analytics",
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "t0kkaaa",
            Email = "nkurakin.cl@gmail.com"
        }
    });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();

    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();

        dbContext.Database.EnsureCreated();
    }

    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "URL Shortener API v1");
        c.RoutePrefix = "docs"; // Доступ по /docs
        c.DocumentTitle = "URL Shortener API Documentation";
    });


}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
