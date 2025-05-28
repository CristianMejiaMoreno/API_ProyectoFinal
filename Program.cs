using API_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;
using API_ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
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

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<API_Context>();
    dataContext.Database.Migrate();
}

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
