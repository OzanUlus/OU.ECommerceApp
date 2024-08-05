using AutoMapper;
using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderManager : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featuresSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featuresSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var fetaureSlider = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featuresSliderCollection.InsertOneAsync(fetaureSlider);
            
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featuresSliderCollection.DeleteOneAsync(fs => fs.FeatureSliderId == id);
        }

        public Task FeatureSliderChangeStatusFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
        {
            var featureSliders = await _featuresSliderCollection.Find(fs => true).ToListAsync();
            var featureSlidersDto = _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
            return featureSlidersDto;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var featureSlider = await _featuresSliderCollection.Find<FeatureSlider>(fs => fs.FeatureSliderId == id).FirstOrDefaultAsync();
            var featureSliderDto = _mapper.Map<GetByIdFeatureSliderDto>(featureSlider);
            return featureSliderDto;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featuresSliderCollection.FindOneAndReplaceAsync(fs => fs.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId,featureSlider);
        }
    }
}
