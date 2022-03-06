using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("WebApiDatabase")
));    

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
    builder => {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// add services to DI container
{
    var services = builder.Services;
    services.AddControllers();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.UseCors(MyAllowSpecificOrigins);
    app.MapControllers();
}

app.Run();