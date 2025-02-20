using Microsoft.EntityFrameworkCore;
using SegundoFinal.Data;
using SegundoFinal.Mapping;
using SegundoFinal.Repositories;
using SegundoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ProductoService>();


builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddScoped<HistorialAccionesRepository>();
builder.Services.AddScoped<HistorialAccionesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
