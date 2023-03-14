using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Dto.Dtos;

namespace UrunSatisTeslimatSistemi.Service.Abstract
{
    public interface ICustomerService : IBaseService<CustomerDto, Customer>
    {
        public Task<CustomerDto> GetSingleCustomerByEmailAsync(string email);
        public Task<List<CustomerDto>> GetAllCustomerWithProducts();
    }
}
