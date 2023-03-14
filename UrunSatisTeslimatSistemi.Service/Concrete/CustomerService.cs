using AutoMapper;
using PracticumHomeWork.Service.Concrete;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract;
using UrunSatisTeslimatSistemi.Dto.Dtos;
using UrunSatisTeslimatSistemi.Service.Abstract;

namespace UrunSatisTeslimatSistemi.Service.Concrete
{
    public class CustomerService : BaseService<CustomerDto, Customer>, ICustomerService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IGenericRepository<Customer> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository) : base(genericRepository, mapper, unitOfWork)
        {
            this.mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> GetAllCustomerWithProducts()
        {
            var customer = await _customerRepository.GetAllWithProducts();

            List<CustomerDto> dto = mapper.Map<List<CustomerDto>>(customer);
            return dto;
        }

        public async Task<CustomerDto> GetSingleCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);

            CustomerDto dto = mapper.Map<CustomerDto>(customer);
            return dto;
        }
    }
}
