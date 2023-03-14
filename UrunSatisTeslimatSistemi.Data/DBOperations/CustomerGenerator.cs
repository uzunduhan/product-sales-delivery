using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Data.DBOperations
{

    public class CustomerGenerator : IEntityTypeConfiguration<Customer>
    {
    

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
            new Customer
            {
                Id= 1,
                Email = "mehmetaslan18@gmail.com",
                Name = "Mehmet",
                Surname = "Aslan"
            },
            new Customer
            {
                Id= 2,
                Email = "ahmetuzun06@hotmail.com",
                Name = "Ahmet",
                Surname = "Uzun"
            },
            new Customer
            {
                Id= 3,
                Email = "kadirsert@gmail.com",
                Name = "Kadir",
                Surname = "Sert"
            });
        }
    }

}