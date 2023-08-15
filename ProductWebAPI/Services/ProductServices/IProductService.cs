using ProductWebAPI.DTOs.ProductDTOs;
using ProductWebAPI.DTOs.ResponseDTOs;

namespace ProductWebAPI.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDTO>>> GetAllProductAsync();
        Task<Response<ResultProductDTO>> GetByIdProductAsync(string id);
        Task<Response<NoContent>> CreateProductAsync(CreateProductDTO createProductDTO);
        Task<Response<NoContent>> UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task<Response<NoContent>> DeleteProductAsync(string productId);
    }
}