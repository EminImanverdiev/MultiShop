using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Database);
            _ProductImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto create)
        {
            var value = _mapper.Map<ProductImage>(create);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(c => c.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _ProductImageCollection.Find<ProductImage>(c => c.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto update)
        {
            var value = _mapper.Map<ProductImage>(update);
            await _ProductImageCollection.FindOneAndReplaceAsync(c => c.ProductImageId == update.ProductImageId, value);
        }
    }
}
