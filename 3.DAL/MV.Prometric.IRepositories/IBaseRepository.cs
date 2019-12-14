using System.Collections.Generic;
using MV.Prometric.EntityModels;

namespace MV.Prometric.IRepositories
{
    public partial interface IBaseRepository<EntityModel> where EntityModel : BaseEntity
    {
        IDataContext DbContext { get; set; }

        List<EntityModel> GetAll();

        void Add(EntityModel entityModel);

        void DeleteAll();

    }
}
