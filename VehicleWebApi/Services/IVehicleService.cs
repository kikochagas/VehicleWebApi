using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleWebApi.Models.Tables;

namespace VehicleWebApi.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetAsync(Guid id);
        Task AddAsync(Vehicle data);
        Task UpdateAsync(Vehicle data);
        Task DeleteAsync(Guid id);
    }
}
