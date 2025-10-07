using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo.Client;
using WebAssemblyDemo.Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<ContainerStorage>();
builder.Services.AddTransient<IServersApiRepository, ServersApiRepository>();
builder.Services.AddHttpClient("ServersApi", client =>
{
    client.BaseAddress = new Uri("https://webassembly-demo-922cb-default-rtdb.asia-southeast1.firebasedatabase.app");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


await builder.Build().RunAsync();