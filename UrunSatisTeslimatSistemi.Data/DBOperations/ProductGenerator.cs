using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Data.DBOperations
{
    public class ProductGenerator : IEntityTypeConfiguration<Product>
    {


        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price= 26000,
            },
            new Product
            {
                Id = 2,
                Name = "Telefon",
                Price = 14350
            },
            new Product
            {
                Id = 3,
                Name = "Gözlük",
                Price = 2500
            });
        }
    }
 
}
