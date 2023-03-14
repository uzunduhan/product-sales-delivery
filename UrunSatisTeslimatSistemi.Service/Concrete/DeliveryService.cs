using AutoMapper;
using PracticumHomeWork.Service.Concrete;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract;
using UrunSatisTeslimatSistemi.Dto.Dtos;
using UrunSatisTeslimatSistemi.Service.Abstract;

namespace UrunSatisTeslimatSistemi.Service.Concrete
{
    public class DeliveryService : BaseService<DeliveryDto, Delivery>, IDeliveryService
    {
        public DeliveryService(IGenericRepository<Delivery> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
