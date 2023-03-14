using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;
using UrunSatisTeslimatSistemi.Data.Repository.Concrete;
using UrunSatisTeslimatSistemi.Data.UnitOfWork.Abstract;

namespace UrunSatisTeslimatSistemi.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public bool disposed;



        public IGenericRepository<Customer> CustomerRepository { get; private set; }
        public IGenericRepository<Delivery> DeliveryRepository { get; private set; }
        public IGenericRepository<Product> ProductRepository { get; private set; }
        public IGenericRepository<CustomerProduct> CustomerProductRepository { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

            CustomerRepository = new GenericRepository<Customer>(_context);
            DeliveryRepository = new GenericRepository<Delivery>(_context);
            ProductRepository = new GenericRepository<Product>(_context);
            CustomerProductRepository= new GenericRepository<CustomerProduct>(_context);
        }



        public  Task CompleteAsync()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());   
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
            return Task.CompletedTask;
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}

