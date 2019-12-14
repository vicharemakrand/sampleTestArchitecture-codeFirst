using MV.Prometric.IRepositories;
using MV.Prometric.ViewModels;
using System.Collections.Generic;

namespace MV.Prometric.IDomainServices
{
    public interface IVehicleService
    {
         IUnitOfWork UnitOfWork { get; set; }
        List<VehicleViewModel> GetAll();
        VehicleViewModel Save(VehicleViewModel viewModel);
    }
}
