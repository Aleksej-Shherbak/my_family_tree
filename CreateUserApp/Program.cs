using CreateUserApp;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
            
var services = new ServiceCollection();
services.AddStorageConfiguration(configuration);
services.AddAuthConfiguration();
services.AddSingleton<CreateUserService>();
services.AddSingleton<Validation>();
services.AddSingleton<Printer>();
services.AddLogging();                  

services.BuildServiceProvider().GetService<CreateUserService>().Run();
