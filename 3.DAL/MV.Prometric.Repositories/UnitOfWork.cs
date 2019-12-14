using MV.Prometric.IRepositories;
using StructureMap.Attributes;
using System;

namespace MV.Prometric.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {
        #region Fields
        
         private IVehicleReposistory _vehicleRepository;
 
        #endregion

        #region Constructors

        public UnitOfWork()
        {
            this.DataContext = new DataContext();
        }

        #endregion

        public virtual IDataContext DataContext { get; set; }

        #region IUnitOfWork Members

        
        [SetterProperty]
        public virtual IVehicleReposistory VehicleRepository
        {
            get { return _vehicleRepository; }
            set
            {
                _vehicleRepository = value;
                _vehicleRepository.DbContext = DataContext;
            }
        }

        public virtual int Commit()
        {
            return DataContext.Commit();
        }

         #endregion

        #region IDisposable Members
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
