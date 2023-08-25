using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.DTO.Customer
{
    public class CustomerDTOResponse:CustomerDTOBase
    {
        public Guid? Guid { get; set; }
    }
}
