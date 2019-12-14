using MV.Prometric.EntityModels;
using MV.Prometric.IDomainServices;
using MV.Prometric.IRepositories;
using MV.Prometric.ViewModels;
using StructureMap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MV.Prometric.DomainServices
{
    public class VehicleService: IVehicleService
    {

        [SetterProperty]
        public virtual IUnitOfWork UnitOfWork
        {
            get; set;
        }

        public virtual List<VehicleViewModel> GetAll()
        {
                var entities = UnitOfWork.VehicleRepository.GetAll();
                return entities.Select(o => new VehicleViewModel { ModelName = o.ModelName }).ToList();
        }

        public virtual VehicleViewModel Save(VehicleViewModel viewModel)
        {
            var entity = new Vehicle {
                Id = viewModel.Id,
                ModelName = viewModel.ModelName,
                Color = viewModel.Color,
                MpgValue = viewModel.MpgValue
                };

                if (viewModel.Id == 0)
                {
                    UnitOfWork.VehicleRepository.Insert(entity);
                    viewModel.Id = entity.Id;
                }
                else
                {
                    throw new NotImplementedException();
                }

                return viewModel;
        }
    }
}
