using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace MV.Prometric.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleReposistory
    {
        public virtual Vehicle Insert(Vehicle vehicle)
        {
            return DbContext.Vehicles.Add(vehicle);
        }


        public virtual void Save()
        {
            DbContext.Commit();
        }


    }
}
