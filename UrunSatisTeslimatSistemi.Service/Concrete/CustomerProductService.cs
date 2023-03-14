using AutoMapper;
using PracticumHomeWork.Service.Concrete;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract;
using UrunSatisTeslimatSistemi.Service.Abstract;

namespace UrunSatisTeslimatSistemi.Service.Concrete
{
    public class CustomerProductService : BaseService<CustomerProduct, CustomerProduct>, ICustomerProductService
    {
        public CustomerProductService(IGenericRepository<CustomerProduct> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
