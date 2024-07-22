using AutoMapper;
using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.CategoryServices
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoriesCollection;
        private readonly IMapper _mapper;

        public CategoryManager(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoriesCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var entity = _mapper.Map<Category>(createCategoryDto);
            await _categoriesCollection.InsertOneAsync(entity);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoriesCollection.DeleteOneAsync(c => c.CategoryId ==id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var categories = await _categoriesCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var category = await _categoriesCollection.Find<Category>(c => c.CategoryId ==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var entity = _mapper.Map<Category>(updateCategoryDto);
            await _categoriesCollection.FindOneAndReplaceAsync(c => c.CategoryId == updateCategoryDto.CategoryId, entity);
        }
    }
}
