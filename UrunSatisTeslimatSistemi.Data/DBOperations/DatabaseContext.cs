using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UrunSatisTeslimatSistemi.Data.Models;

namespace UrunSatisTeslimatSistemi.Data.DBOperations
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=.;Database=UrunSatisTeslimatDb;Trusted_Connection=True;");

        public DbSet<Customer> Customers {get; set;}
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerProduct>()
                .HasOne(c => c.Customer)
                .WithMany(cp => cp.Customer_Products)
                .HasForeignKey(ci => ci.CustomerId);

            modelBuilder.Entity<CustomerProduct>()
              .HasOne(c => c.Product)
              .WithMany(cp => cp.Customer_Products)
              .HasForeignKey(ci => ci.ProductId);


           // modelBuilder.Entity<Movie>()
           //.HasOne(x => x.Genre)
           //.WithMany(p => p.Movies)
           //.IsRequired(false)
           //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}