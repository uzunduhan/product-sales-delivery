using Microsoft.EntityFrameworkCore;
using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;

namespace UrunSatisTeslimatSistemi.Data.Repository.Concrete
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAllWithProducts()
        {
             return await _context.Customers.Include(x => x.Deliveries).Include(x=>x.Customer_Products).ThenInclude(x=>x.Product).ToListAsync();
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _context.Customers.Include(x=>x.Deliveries).Include(x=>x.Customer_Products).ThenInclude(x=>x.Product).Where(x => x.Email == email).FirstOrDefaultAsync();
        }

    }
}
