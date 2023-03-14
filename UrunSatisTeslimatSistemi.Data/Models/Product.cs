using UrunSatisTeslimatSistemi.Base.Model;

namespace UrunSatisTeslimatSistemi.Data.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<CustomerProduct>? Customer_Products { get; set; }

    }
}
