using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleWebApi.Models.Tables;
using VehicleWebApi.Models.UnitOfWork;

namespace VehicleWebApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _repository;

        public VehicleService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Vehicle data)
        {
            try
            {
                await _repository.Vehicles.AddAsync(data);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _repository.Vehicles.DeleteAsync(id);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            try
            {
                return await _repository.Vehicles.GetAllAsync("Model");
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task<Vehicle> GetAsync(Guid id)
        {
            try
            {
                return await _repository.Vehicles.GetAsync(id);
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task UpdateAsync(Vehicle data)
        {
            try
            {
                await _repository.Vehicles.UpdateAsync(data.RequestId, data);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }



    }
}
