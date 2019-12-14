using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;
using System.Data.Entity;

namespace MV.Prometric.Repositories
{
    public partial class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("DefaultConnection") { }
 
        public DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<T> DbSet<T>() where T : BaseEntity
        {
            return Set<T>();
        }

        public virtual int Commit()
        {
            return base.SaveChanges();
        }  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
