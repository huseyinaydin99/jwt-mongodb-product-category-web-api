using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.DTOs.ProductDTOs;
using ProductWebAPI.Services.ProductServices;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductById(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            return Ok(values);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var values = await _productService.CreateProductAsync(createProductDTO);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            await _productService.DeleteProductAsync(productId);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateProductAsync(updateProductDTO);
            return Ok();
        }
    }
}