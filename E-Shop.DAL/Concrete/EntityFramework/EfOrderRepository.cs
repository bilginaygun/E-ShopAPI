using E_Shop.DAL.Abstract;
using E_Shop.DAL.Concrete.EntityFramework.DataManagement;
using E_ShopAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.DAL.Concrete.EntityFramework
{
    public class EfOrderRepository : EfRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }
    }
}
