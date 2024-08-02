using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductServices
{
    public class ProductManager : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductManager(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var entity = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(entity);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(p=>p.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
          var products =  await _productCollection.Find(p=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
            
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find<Product>(p => p.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var product in values)
            {
                product.Category = await _categoryCollection.Find<Category>(c => c.CategoryId == product.CategoryId).FirstOrDefaultAsync();
                
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
           var entity = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(p => p.ProductId == updateProductDto.ProductId, entity);
        }
    }
}
