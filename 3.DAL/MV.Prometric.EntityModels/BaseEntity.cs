using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MV.Prometric.EntityModels
{
    [Serializable]
    public abstract partial class BaseEntity
    {
 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

    }
}
