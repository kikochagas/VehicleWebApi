using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleWebApi.Models.Tables;

namespace VehicleWebApi.Services
{
    public interface IModelService
    {
        Task<IEnumerable<Model>> GetAllAsync();
        Task<Model> GetAsync(Guid id);
        Task AddAsync(Model data);
        Task UpdateAsync(Model data);
        Task DeleteAsync(Guid id);
    }
}
