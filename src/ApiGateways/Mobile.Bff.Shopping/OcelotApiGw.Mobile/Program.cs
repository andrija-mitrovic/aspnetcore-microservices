using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot().AddCacheManager(x => x.WithDictionaryHandle());
builder.Configuration.AddJsonFile($"ocelot.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true);
builder.Configuration.AddConfiguration(builder.Configuration.GetSection("Logging"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
