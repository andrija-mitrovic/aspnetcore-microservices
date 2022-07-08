using Basket.API;
using Basket.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddBasketAPIServices(builder.Configuration);

    // Configure Elasticsearch
    builder.AddElasticsearch();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHealthChecks("/health");
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
