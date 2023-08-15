using ProductWebAPI.DTOs.CategoryDTOs;
using ProductWebAPI.DTOs.ResponseDTOs;

namespace ProductWebAPI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDTO>>> GetAllCategoryAsync();
        Task<Response<ResultCategoryDTO>> GetByIdCategoryAsync(string categoryId);
        Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task<Response<NoContent>> DeleteCategoryAsync(string categoryId);
        Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
    }
}