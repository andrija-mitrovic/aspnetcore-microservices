using Shopping.Aggregator.Mobile;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddShoppingAggregatorMobileServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
