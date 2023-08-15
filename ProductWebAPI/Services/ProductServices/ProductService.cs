using AutoMapper;
using Casgem.MicroService.Shared.DTOs;
using CasgemMicroservice.Catalog.Settings.Abstracts;
using CasgemMicroservice.Services.Catalog.DTOs.CategoryDTOs;
using CasgemMicroservice.Services.Catalog.DTOs.ProductDTOs;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Shared.DTOs;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<NoContent>> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var values = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteProductAsync(string productId)
        {
            var value = await _productCollection.DeleteOneAsync(x => x.ProductId == productId);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultProductDTO>>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDTO>>.Success(_mapper.Map<List<ResultProductDTO>>(values), 200);
        }

        public async Task<Response<ResultProductDTO>> GetByIdProductAsync(string productId)
        {
            var values = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            return values == null ? Response<ResultProductDTO>.Fail("Ürün bulunamadı.", 404) : Response<ResultProductDTO>.Success(_mapper.Map<ResultProductDTO>(values), 200);
        }

        public async Task<Response<NoContent>> UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var values = _mapper.Map<Product>(updateProductDTO);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDTO.ProductId, values);
            return Response<NoContent>.Success(204);
        }
    }
}
