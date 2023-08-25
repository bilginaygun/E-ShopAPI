using E_Shop.DAL.Abstract.DataManagement;
using E_ShopAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.DAL.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
