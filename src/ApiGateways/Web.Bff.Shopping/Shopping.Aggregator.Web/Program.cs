using Shopping.Aggregator.Web;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddShoppingAggregatorWebServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
