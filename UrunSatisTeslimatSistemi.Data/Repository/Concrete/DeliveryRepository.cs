using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.Repository.Concrete;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class DeliveryRepository : GenericRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(DatabaseContext context) : base(context)
        {
        }

    }
}
