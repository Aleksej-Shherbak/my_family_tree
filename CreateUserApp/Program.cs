using CreateUserApp;
using Domains;
using EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
            
var services = new ServiceCollection();
services.AddStorageConfiguration(configuration);
services.AddIdentity<User, IdentityRole>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequiredLength = 1;
        opt.Password.RequireLowercase = false;
        opt.Password.RequiredUniqueChars = 0;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireUppercase = false;
        opt.SignIn.RequireConfirmedEmail = true;
                
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


services.AddSingleton<CreateUserService>();
services.AddSingleton<Validation>();
services.AddSingleton<Printer>();
services.AddLogging();                  

services.BuildServiceProvider().GetService<CreateUserService>().Run();
