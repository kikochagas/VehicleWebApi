using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleWebApi.Models.Tables;
using VehicleWebApi.Models.UnitOfWork;

namespace VehicleWebApi.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _repository;

        public ModelService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Model data)
        {
            try
            {
                await _repository.Models.AddAsync(data);
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
                await _repository.Models.DeleteAsync(id);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            try
            {
                return await _repository.Models.GetAllAsync();
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task<Model> GetAsync(Guid id)
        {
            try
            {
                return await _repository.Models.GetAsync(id);
            }
            catch (Exception ex)
            {
                //aqui pondria el log..
                throw;
            }
        }

        public async Task UpdateAsync(Model data)
        {
            try
            {
                await _repository.Models.UpdateAsync(data.Id, data);
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
