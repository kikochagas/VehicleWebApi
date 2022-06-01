using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApi.Models;

namespace VehicleWebApi.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private VehicleDBContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(VehicleDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            await _dbSet.AddAsync(data);
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var data = await _dbSet.FindAsync(id);
            if (data != null)
                _dbSet.Remove(data);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string entityToInclude = null)
        {
            if(entityToInclude != null)
            {
                return await _dbSet.Include(entityToInclude).ToListAsync();
            }
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, TEntity data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(data));
            _context.Update(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
