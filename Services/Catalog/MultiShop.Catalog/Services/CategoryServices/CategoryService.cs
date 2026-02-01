using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Database);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto create)
        {
            var value=_mapper.Map<Category>(create);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(c=>c.CategoryId==id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values=await _categoryCollection.Find(c=>true).ToListAsync();
            return  _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value=await _categoryCollection.Find<Category>(c=>c.CategoryId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto update)
        {
            var value=_mapper.Map<Category>(update);
            await _categoryCollection.FindOneAndReplaceAsync(c=>c.CategoryId==update.CategoryId,value);
        }
    }
}
