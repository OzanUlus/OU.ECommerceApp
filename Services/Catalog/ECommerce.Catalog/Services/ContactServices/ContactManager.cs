using AutoMapper;
using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ContactServices
{
    public class ContactManager : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactManager(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var entity = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(entity);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(c => c.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var categories = await _contactCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(categories);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var Contact = await _contactCollection.Find<Contact>(c => c.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(Contact);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var entity = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(c => c.ContactId == updateContactDto.ContactId, entity);
        }
    }
}
