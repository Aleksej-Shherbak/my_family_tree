using Dto.Options;
using Infrastructure.Di.Auth;
using Infrastructure.Middlewares;
using Services.FileService;
using ServicesInterfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFileSystemService, FileSystemService>();
builder.Services.Configure<FileStorageOptions>(builder.Configuration.GetSection(nameof(FileStorageOptions)));
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(nameof(AuthOptions)));


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

app.UseJwtCookieReaderCookie();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();