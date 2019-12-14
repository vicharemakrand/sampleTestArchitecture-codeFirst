using MV.Prometric.EntityModels;
using System.Collections.Generic;

namespace MV.Prometric.IRepositories
{
    public interface IVehicleReposistory : IBaseRepository<Vehicle>
    {
        Vehicle Insert(Vehicle vehicle);

        void Save();

    }
}
