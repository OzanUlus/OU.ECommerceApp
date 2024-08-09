using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductDetailServices
{
    public class ProductDetailManager : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var entity = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(entity);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(pd => pd.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllAsync()
        {
            var productsDetail = await _productDetailCollection.Find(pd => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productsDetail);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find<ProductDetail>(pd => pd.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find<ProductDetail>(pd => pd.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var entity = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(pd => pd.ProductDetailId == updateProductDetailDto.ProductDetailId, entity);
        }

       
    }
}
