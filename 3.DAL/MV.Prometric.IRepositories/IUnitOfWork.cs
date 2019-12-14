using System;

namespace MV.Prometric.IRepositories
{
    public partial interface IUnitOfWork : IDisposable
    {
        int Commit();
        IDataContext DataContext { get; set; }
        IVehicleReposistory VehicleRepository { get; set; }
     }
}
