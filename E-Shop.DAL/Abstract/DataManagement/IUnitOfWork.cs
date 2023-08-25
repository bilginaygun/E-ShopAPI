using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangeAsync();
    }
}

