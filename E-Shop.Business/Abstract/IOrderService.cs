using E_ShopAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task OrderAddV1(Order order, List<OrderDetail> orderDetails);
    }
}
