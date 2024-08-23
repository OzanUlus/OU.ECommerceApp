using AutoMapper;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        }

        public  long GetBrandCount()
        {
            var values = _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
            return values;
        }

        public long GetCategoryCount()
        {
            var values = _categoryCollection.CountDocuments(FilterDefinition<Category>.Empty);
            return values;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
              new BsonDocument("$group", new BsonDocument
              {
                  {"_id",null },
                  {"avaragePrice",new BsonDocument("$avg","$ProductPrice") }
              })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var value = result.FirstOrDefault().GetValue("avaragePrice",decimal.Zero).AsDecimal;
            return value;
        }

        public long GetProductCount()
        {
            var values = _productCollection.CountDocuments(FilterDefinition<Product>.Empty);
            return values;
        }
    }
}
