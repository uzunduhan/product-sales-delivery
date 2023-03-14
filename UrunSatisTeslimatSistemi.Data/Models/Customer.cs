using UrunSatisTeslimatSistemi.Base.Model;

namespace UrunSatisTeslimatSistemi.Data.Models
{
    public class Customer : BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<CustomerProduct> Customer_Products { get; set; }
        public List<Delivery> Deliveries { get; set; }  


    }
}
