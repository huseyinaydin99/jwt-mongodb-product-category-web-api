using Casgem.MicroService.Shared.DTOs;
using CasgemMicroservice.Services.Catalog.DTOs.CategoryDTOs;
using CasgemMicroservice.Services.Catalog.DTOs.ProductDTOs;
using CasgemMicroservice.Shared.DTOs;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices
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
