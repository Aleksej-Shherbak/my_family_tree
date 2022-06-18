using Domains;
using Email;
using EntityFramework;
using Microsoft.AspNetCore.Identity;
using WebApi.Di.Auth;
using WebApi.Di.Cors;
using WebApi.Di.Swagger;
using WebApi.Middlewares;
using WebApi.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorsConfiguration();
builder.Services.AddAuthConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddEmailConfiguration(builder.Configuration);
builder.Services.AddStorageConfiguration(builder.Configuration);

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseCors();
app.UseExceptionHandlerMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();