using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Dto.Dtos;

namespace UrunSatisTeslimatSistemi.Service.Abstract
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        public Task<ProductDto> GetSingleProductByNameAsync(string name);

        Task UpdateProductAsync(UpdateProductDto updateResource);

    }
}
