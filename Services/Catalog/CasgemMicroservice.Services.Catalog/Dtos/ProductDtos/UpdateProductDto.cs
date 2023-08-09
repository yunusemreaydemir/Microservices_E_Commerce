using CasgemMicroservice.Services.Catalog.Models;

namespace CasgemMicroservice.Services.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductStock { get; set; }
        public string ProductDescreption { get; set; }
        public string ProductIMage { get; set; }
        public string CategoryID { get; set; }    
    }
}
