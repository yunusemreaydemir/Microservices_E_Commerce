using CasgemMicroservice.Services.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CasgemMicroservice.Services.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductStock { get; set; }
        public string ProductDescreption { get; set; }
        public string ProductIMage { get; set; }
        public string CategoryID { get; set; } 
    }
}
