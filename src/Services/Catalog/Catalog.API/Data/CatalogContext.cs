using Catalog.API.Entities;
using Catalog.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration, IOptions<MongoSettings> mongo)
        {
            //var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            //Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            var client = new MongoClient(mongo.Value.ConnectionString);
            var database = client.GetDatabase(mongo.Value.DatabaseName);

            Products = database.GetCollection<Product>(mongo.Value.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
