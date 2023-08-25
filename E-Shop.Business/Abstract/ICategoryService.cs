using E_ShopAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
       Task<Category> AddAsync(Category category, Product product);
    }
}
