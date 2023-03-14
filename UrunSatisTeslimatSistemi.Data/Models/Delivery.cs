using UrunSatisTeslimatSistemi.Base.Model;

namespace UrunSatisTeslimatSistemi.Data.Models
{
    public class Delivery : BaseModel
    {
        public string Adress { get; set; }
        public int? CustomerId { get; set; }
        public  Customer customer { get; set; }
    }
}
