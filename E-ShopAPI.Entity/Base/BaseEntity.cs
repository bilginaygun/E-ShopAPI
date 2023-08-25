using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.GUID = Guid.NewGuid();
        }
        public int ID { get; set; }
        public Guid GUID { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
