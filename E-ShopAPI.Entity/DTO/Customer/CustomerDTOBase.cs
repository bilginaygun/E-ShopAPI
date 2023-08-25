using E_ShopAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopAPI.Entity.DTO.Customer
{
    public class CustomerDTOBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Customername { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
