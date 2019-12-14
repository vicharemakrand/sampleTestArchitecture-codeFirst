using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MV.Prometric.Repositories
{

    public  partial class BaseRepository<EntityModel> : IBaseRepository<EntityModel> where EntityModel : BaseEntity
    {
        public IDataContext DbContext  { get; set; }

        protected DbSet<EntityModel> DbSet
        {
            get
            {
                return DbContext.DbSet<EntityModel>();
            }
        }

        public virtual List<EntityModel> GetAll()
        {
            return DbSet.ToList();
        }


        public virtual void Add(EntityModel entity)
        {
            DbSet.Add(entity);
        }

        
        public virtual void DeleteAll()
        {
            var models = DbSet.ToList();
            DbSet.RemoveRange(models);
        }

    }
}
