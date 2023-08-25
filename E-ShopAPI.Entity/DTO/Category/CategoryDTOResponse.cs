using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.DTO.Category
{
    public class CategoryDTOResponse : CategoryDTOBase
    {
        public Guid? Guid { get; set; }
        public bool? IsActive { get; set; }

    }
}
