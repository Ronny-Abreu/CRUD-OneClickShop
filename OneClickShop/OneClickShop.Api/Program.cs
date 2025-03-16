using OneClickShop.Application.Services;
using OneClickShop.Domain.Data;
using OneClickShop.Infrastructura.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Contenedor
builder.Services.AddControllers();

// Configuración de la base de datos
builder.Services.AddDbContext<OneClickSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

// Configuración de Swagger
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configuración de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
