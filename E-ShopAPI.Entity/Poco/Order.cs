using E_ShopAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.Poco
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        public int CustomerID { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public Customer Customer { get; set; }
    }
}
