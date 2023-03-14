﻿using Microsoft.EntityFrameworkCore;
using UrunSatisTeslimatSistemi.Data.DBOperations;
using UrunSatisTeslimatSistemi.Data.Repository.Abstract;

namespace UrunSatisTeslimatSistemi.Data.Repository.Concrete
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        protected readonly DatabaseContext _context;
        private DbSet<Entity> entities;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            this.entities = _context.Set<Entity>();
        }



        public virtual async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
        }

        public virtual async Task InsertAsync(Entity entity)
        {
            await entities.AddAsync(entity);
        }

        public virtual void RemoveAsync(Entity entity)
        {

            var type = typeof(Entity).Name;


            entities.Remove(entity);

        }

        public virtual void Update(Entity entity)
        {
            entities.Update(entity);
        }
    }
}
