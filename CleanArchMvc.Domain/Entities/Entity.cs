using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        //DateTime CreatedDate { get; set; }
        //DateTime? ModifiedDate { get; set; }
        //string CreatedBy { get; set; }
        //string ModifiedBy { get; set; }
    }
}
