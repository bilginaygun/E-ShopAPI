using E_ShopAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.Poco
{


    public class Product : AuditableEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FeaturedImage { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

}
