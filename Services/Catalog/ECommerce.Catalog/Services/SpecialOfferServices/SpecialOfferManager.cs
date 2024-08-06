using AutoMapper;
using ECommerce.Catalog.Dtos.SpecailOfferDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferManager : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;

        public SpecialOfferManager(IMapper mapper, IDatabaseSettings databaseSettings )
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var specialOffer = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(specialOffer);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(so => so.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
        {
            var specialOffers = await _specialOfferCollection.Find(so => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(specialOffers);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdCategoryAsync(string id)
        {
            var specialOffer = await _specialOfferCollection.Find(so => so.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(specialOffer);
        }

        public async Task UpdateCategoryAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var specialOffer = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(so => so.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, specialOffer);
        }
    }
}
