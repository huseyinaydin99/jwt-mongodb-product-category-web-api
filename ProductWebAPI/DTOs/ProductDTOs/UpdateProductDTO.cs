using MongoDB.Bson.Serialization.Attributes;

namespace ProductWebAPI.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescripiton { get; set; }
        public string ProductImage { get; set; }
        public string CategoryId { get; set; }
    }
}
