using Catalog.API;
using Catalog.API.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddCatalogAPIServices(builder.Configuration);

    // Configure Elasticsearch
    builder.AddElasticsearch();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseHealthChecks("/health");
    app.MapControllers();
    app.MapHealthChecks("/health/dependency", new HealthCheckOptions()
    {
        ResponseWriter = async (context, report) =>
        {
            var result = JsonConvert.SerializeObject(
                new
                {
                    status = report.Status.ToString(),
                    services = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                });
            context.Response.ContentType = MediaTypeNames.Application.Json;

            await context.Response.WriteAsync(result);
        }
    });
    app.Run();
}
