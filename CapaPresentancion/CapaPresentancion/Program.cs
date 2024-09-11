using CapaDatos;
using CapaNegocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var conn = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<ClaseContexto>(x => x.UseSqlServer(conn));
builder.Services.AddScoped<RegistroUsuarioNegocio>();
builder.Services.AddScoped<LoginNegocio>();
builder.Services.AddScoped<CitasNegocio>();
builder.Services.AddScoped<AdminEspecialidaNegocio>();
builder.Services.AddScoped<DashboardCitasNegocio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
