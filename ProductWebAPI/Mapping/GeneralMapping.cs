using AutoMapper;
using CasgemMicroservice.Services.Catalog.Models;
using ProductWebAPI.DTOs.CategoryDTOs;
using ProductWebAPI.DTOs.ProductDTOs;

namespace ProductWebAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        }
    }
}
