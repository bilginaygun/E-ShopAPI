using E_ShopAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.Poco
{
    public class OrderDetail : AuditableEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public double? Quantity { get; set; }
        public double? Discount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

    }
}
