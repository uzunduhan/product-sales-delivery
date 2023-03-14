using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;

namespace UrunSatisTeslimatSistemi.Data.Repository.Concrete
{
    public class CustomerProductRepository : GenericRepository<CustomerProduct>, ICustomerProductRepository
    {
        public CustomerProductRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
