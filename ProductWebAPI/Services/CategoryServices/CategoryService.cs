using AutoMapper;
using CasgemMicroservice.Catalog.Settings.Abstracts;
using MongoDB.Driver;
using ProductWebAPI.DTOs.CategoryDTOs;
using ProductWebAPI.DTOs.ResponseDTOs;
using ProductWebAPI.Models;

namespace ProductWebAPI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var value = _mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(value);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteCategoryAsync(string categoryId)
        {
            var values = await _categoryCollection.DeleteOneAsync(x => x.CategoryId == categoryId);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultCategoryDTO>>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return Response<List<ResultCategoryDTO>>.Success(_mapper.Map<List<ResultCategoryDTO>>(values), 200);
        }

        public async Task<Response<ResultCategoryDTO>> GetByIdCategoryAsync(string categoryId)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            return values == null ? Response<ResultCategoryDTO>.Fail("Kategori bulunamadı.", 404) : Response<ResultCategoryDTO>.Success(_mapper.Map<ResultCategoryDTO>(values), 200);
        }

        public async Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var values = _mapper.Map<Category>(updateCategoryDTO);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDTO.CategoryId, values);
            return result == null ? Response<NoContent>.Fail("Kategori bulunamadı.", 404) : Response<NoContent>.Success(204);
        }
    }
}
