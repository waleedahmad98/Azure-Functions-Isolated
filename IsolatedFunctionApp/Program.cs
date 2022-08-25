using IsolatedFunctionApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults().ConfigureServices(services =>
    {
        services.AddSingleton<IData, Data>();
    })
    .Build();

host.Run();
