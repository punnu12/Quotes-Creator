using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using QuotesCreator_Frontend;
using QuotesCreator_Frontend.Services.QuoteCreatorServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7134") });
builder.Services.AddScoped<AddQuoteService>();
builder.Services.AddScoped<DeleteQuoteService>();
builder.Services.AddScoped<GetQuoteService>();
builder.Services.AddScoped<SearchQuoteService>();
builder.Services.AddScoped<UpdateQuoteService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
