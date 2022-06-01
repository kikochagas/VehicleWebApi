using System.Threading.Tasks;
using VehicleWebApi.Models.Repository;
using VehicleWebApi.Models.Tables;

namespace VehicleWebApi.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private VehicleDBContext _context;
        public IRepository<Model> _models;
        public IRepository<Vehicle> _vehicles;

        public IRepository<Model> Models
        {
            get { return _models == null ?
                    _models = new Repository<Model>(_context) : _models; 
                
                }

        }

        public IRepository<Vehicle> Vehicles
        {
            get
                {
                    return _vehicles == null ?
                    _vehicles = new Repository<Vehicle>(_context) : _vehicles;
                }
        }
        public UnitOfWork(VehicleDBContext context)
        {
            _context = context;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
