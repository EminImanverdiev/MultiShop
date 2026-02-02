using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Database);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task CreateProductAsync(CreateProductDto create)
        {
            var value= _mapper.Map<Product>(create);
            await _productCollection.InsertOneAsync(value);

        }

        public async Task DeleteProductAsync(string id)
        {
           await _productCollection.DeleteOneAsync(p=>p.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(p => p.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto update)
        {
            var value = _mapper.Map<Product>(update);
            await _productCollection.FindOneAndReplaceAsync(p=>p.ProductId==update.ProductId,value);
        }
    }
}
