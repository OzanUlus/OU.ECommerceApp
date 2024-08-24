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

        public async Task<long> GetBrandCount()
        {
            var values = await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
            return values;
        }

        public async Task<long> GetCategoryCount()
        {
            var values = await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
            return values;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(p => p.ProductPrice);
            var projection = Builders<Product>.Projection.Include(p => 
                                               p.ProductName).Exclude("ProductId");

            var product = await _productCollection.Find(filter)
                                                  .Sort(sort)
                                                  .Project(projection)
                                                  .FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(p => p.ProductPrice);
            var projection = Builders<Product>.Projection.Include(p =>
                                               p.ProductName).Exclude("ProductId");

            var product = await _productCollection.Find(filter)
                                                  .Sort(sort)
                                                  .Project(projection)
                                                  .FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
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

        public async Task<long> GetProductCount()
        {
            var values = await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
            return values;
        }
    }
}
