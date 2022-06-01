using System.Threading.Tasks;
using VehicleWebApi.Models.Repository;
using VehicleWebApi.Models.Tables;

namespace VehicleWebApi.Models.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Model> Models { get; }

        public IRepository<Vehicle> Vehicles { get; }

        public Task SaveAsync();

    }
}
