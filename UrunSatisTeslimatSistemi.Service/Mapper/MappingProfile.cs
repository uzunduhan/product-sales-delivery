using AutoMapper;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Dto.Dtos;

namespace UrunSatisTeslimatSistemi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            //CreateMap<Customer, CustomerDto>().ReverseMap();
           // CreateMap<Delivery, DeliveryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap().ForMember(destination => destination.Customer_Products, opt => opt.MapFrom(src => src.Customer_Products))
            .ForMember(destination => destination.Deliveries, opt=>opt.MapFrom(src=>src.Deliveries));


            CreateMap<Delivery, DeliveryDto>()
                .ForMember(destination => destination.Customer, opt => opt.MapFrom(src => src.customer.Name));

        }
    }
}
