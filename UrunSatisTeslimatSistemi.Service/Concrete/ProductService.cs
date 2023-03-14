using AutoMapper;
using PracticumHomeWork.Service.Concrete;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract;
using UrunSatisTeslimatSistemi.Dto.Dtos;
using UrunSatisTeslimatSistemi.Service.Abstract;

namespace UrunSatisTeslimatSistemi.Service.Concrete
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IGenericRepository<Product> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository) : base(genericRepository, mapper, unitOfWork)
        {
            this.mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }


        public async Task<ProductDto> GetSingleProductByNameAsync(string name)
        {
            var product = await _productRepository.GetByNameAsync(name);

            ProductDto dto = mapper.Map<ProductDto>(product);
            return dto;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateResource)
        {
            var product = await _productRepository.GetByIdAsync(updateResource.Id);


            mapper.Map(updateResource, product);

            _productRepository.Update(product);
            await _unitOfWork.CompleteAsync();

        }
    }
}
