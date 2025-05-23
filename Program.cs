using API_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;
using API_ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<API_Context>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("API_Connection"));
    }
);

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<UsuarioRolService>();
builder.Services.AddScoped<CiudadService>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<ModalidService>();

var app = builder.Build();

using(var scope  = app.Services.CreateScope() )
{
    var dataContext = scope.ServiceProvider.GetRequiredService<API_Context>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
