using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MyApi;
using MyApi.Infrastructure.JwtUtil;
using Presentation.Facade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddOpenApi();
builder.Services.InitFacade();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.InitConfig(connectionString);

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
