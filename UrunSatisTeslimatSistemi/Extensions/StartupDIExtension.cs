using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PracticumHomeWork.Data.Repository.Concrete;
using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.Repository.Concrete;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Concrete;
using UrunSatisTeslimatSistemi.Service.Abstract;
using UrunSatisTeslimatSistemi.Service.Concrete;
using UrunSatisTeslimatSistemi.Service.Mapper;

namespace UrunSatisTeslimatSistemi.Extensions
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGenericRepository<Customer>, GenericRepository<Customer>>();
            services.AddScoped<IGenericRepository<Delivery>, GenericRepository<Delivery>>();
            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IGenericRepository<CustomerProduct>, GenericRepository<CustomerProduct>>();


            services.AddDbContext<DatabaseContext>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerProductService, CustomerProductService>();
            services.AddScoped<IDeliveryService, DeliveryService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
