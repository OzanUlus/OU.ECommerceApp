using AutoMapper;
using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.BrandsServices
{
    public class BrandManager : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandManager(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var entity = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(entity);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(c => c.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllAsync()
        {
            var brands = await _brandCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(brands);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var brand = await _brandCollection.Find<Brand>(c => c.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(brand);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var entity = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(c => c.BrandId == updateBrandDto.BrandId, entity);
        }
    }
}
