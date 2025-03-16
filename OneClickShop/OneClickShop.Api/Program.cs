using OneClickShop.Application.Services;
using OneClickShop.Domain.Data;
using OneClickShop.Infrastructura.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Contenedor
builder.Services.AddControllers();

// Configuraci�n de la base de datos
builder.Services.AddDbContext<OneClickSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyecci�n de dependencias
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

// Configuraci�n de Swagger
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configuraci�n de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
