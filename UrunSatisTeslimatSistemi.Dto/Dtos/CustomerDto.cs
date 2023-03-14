using System.ComponentModel.DataAnnotations;
using UrunSatisTeslimatSistemi.Base.Dto;
using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Dto.Dtos
{
    public class CustomerDto : BaseDto
    {
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<CustomerProduct>? Customer_Products { get; set; }
        public List<Delivery> Deliveries { get; set; }
    }
}
