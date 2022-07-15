using Discount.API;
using Discount.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDiscountAPIServices(builder.Configuration);

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
    app.MigrateDatabase<Program>();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}