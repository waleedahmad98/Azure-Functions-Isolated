using IsolatedFunctionApp.Data;
using IsolatedFunctionApp.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(builder =>
    {
        builder.UseMiddleware<Middleware>();
    }).ConfigureServices(services =>
    {
        services.AddSingleton<IData, Data>();
    })
    .Build();

host.Run();
