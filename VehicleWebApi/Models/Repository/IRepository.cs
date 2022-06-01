using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleWebApi.Models.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string entitiesToInclude = null);
        Task<TEntity> GetAsync(Guid id);
        Task AddAsync(TEntity data);
        Task UpdateAsync(Guid id, TEntity data);
        Task DeleteAsync(Guid id);

        Task SaveAsync();
    }
}
