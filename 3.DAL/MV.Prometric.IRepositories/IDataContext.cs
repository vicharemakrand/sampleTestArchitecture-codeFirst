using MV.Prometric.EntityModels;
using System;
using System.Data.Entity;

namespace MV.Prometric.IRepositories
{
    public partial interface IDataContext : IDisposable
    {
        int Commit();
        DbSet<T> DbSet<T>() where T : BaseEntity;
        DbSet<Vehicle> Vehicles { get; set; }
    }
}
