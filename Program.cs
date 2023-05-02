using Blazored.LocalStorage;
using Blazored.SessionStorage; 
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorChatToolKit;
using BlazorChatToolKit.Services;
using BlazorChatToolKit.Shared.EncryptProviders;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage(); 

builder.Services.AddScoped<BlazorChatToolKit.Shared.IEncryptProvider, AesJsProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ToggleSettingsService>();

await builder.Build().RunAsync();
