using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Data.Repository.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<Customer> GetByEmailAsync(string email);
        public Task<List<Customer>> GetAllWithProducts();
    }
}
