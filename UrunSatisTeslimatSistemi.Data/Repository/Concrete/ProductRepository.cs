using Microsoft.EntityFrameworkCore;
using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.Repository.Concrete;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Products.Include(x=>x.Customer_Products).ThenInclude(x=>x.Customer).Where(x => x.Name == name).SingleOrDefaultAsync();
        }


    }
}
