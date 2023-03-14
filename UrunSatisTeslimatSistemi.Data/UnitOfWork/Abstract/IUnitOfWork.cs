using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;

namespace UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> CustomerRepository { get; }
        IGenericRepository<Delivery> DeliveryRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<CustomerProduct> CustomerProductRepository { get; }


        Task CompleteAsync();
    }
}
