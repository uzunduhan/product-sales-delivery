using UrunSatisTeslimatSistemi.Base.Dto;
using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Dto.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public List<CustomerProduct>? Customer_Products { get; set; }
    }
}
