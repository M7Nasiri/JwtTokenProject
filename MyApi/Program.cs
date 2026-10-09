using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using MyApi;
using MyApi.Infrastructure.JwtUtil;
using Presentation.Facade;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
// Source - https://stackoverflow.com/a/58972781
// Posted by Alex, modified by community. See post 'Timeline' for change history
// Retrieved 2026-10-09, License - CC BY-SA 4.0

builder.Services.AddSwaggerGen(options =>
{
    // ۱. تعریف شمای امنیتی
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "توکن JWT خود را وارد کنید"
    });

    // ۲. روش جدید دات‌نت ۱۰ و Microsoft.OpenApi 2.0
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", document),
            new List<string>()
        }
    });
});
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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
