using Domains;
using EntityFramework;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using WebApi.Configuration.Auth;
using WebApi.Configuration.Options;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);

// Database and cache 
builder.Services.AddStorageConfiguration(builder.Configuration);
builder.Services.AddAuthConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseExceptionHandlerMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();