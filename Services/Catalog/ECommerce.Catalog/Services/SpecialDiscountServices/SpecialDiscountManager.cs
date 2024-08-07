using AutoMapper;
using ECommerce.Catalog.Dtos.SpecialDiscountDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.SpecialDiscountServices
{
    public class SpecialDiscountManager : ISpecialDiscountService
    {
        private readonly IMongoCollection<SpecialDiscount> _specialDiscountCollection;
        private readonly IMapper _mapper;

        public SpecialDiscountManager(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialDiscountCollection = database.GetCollection<SpecialDiscount>(_databaseSettings.SpecialDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialDiscountAsync(CreateSpecialDiscountDto createSpecialDiscountDto)
        {
            var entity = _mapper.Map<SpecialDiscount>(createSpecialDiscountDto);
            await _specialDiscountCollection.InsertOneAsync(entity);
        }

        public async Task DeleteSpecialDiscountAsync(string id)
        {
            await _specialDiscountCollection.DeleteOneAsync(c => c.SpecialDiscountId == id);
        }

        public async Task<List<ResultSpecialDiscountDto>> GetAllAsync()
        {
            var categories = await _specialDiscountCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialDiscountDto>>(categories);
        }

        public async Task<GetByIdSpecialDiscountDto> GetByIdSpecialDiscountAsync(string id)
        {
            var SpecialDiscount = await _specialDiscountCollection.Find<SpecialDiscount>(c => c.SpecialDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialDiscountDto>(SpecialDiscount);
        }

        public async Task UpdateSpecialDiscountAsync(UpdateSpecialDiscountDto updateSpecialDiscountDto)
        {
            var entity = _mapper.Map<SpecialDiscount>(updateSpecialDiscountDto);
            await _specialDiscountCollection.FindOneAndReplaceAsync(c => c.SpecialDiscountId == updateSpecialDiscountDto.SpecialDiscountId, entity);
        }
    }
}
