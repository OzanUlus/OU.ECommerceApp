using AutoMapper;
using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.AboutServices
{
    public class AboutManager : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutManager(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var entity = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(c => c.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var abouts = await _aboutCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var about = await _aboutCollection.Find<About>(c => c.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(about);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var entity = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(c => c.AboutId == updateAboutDto.AboutId, entity);
        }
    }
}
