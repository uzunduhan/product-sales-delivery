using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Data.Repository.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public Task<Product> GetByNameAsync(string name);
    }
}
