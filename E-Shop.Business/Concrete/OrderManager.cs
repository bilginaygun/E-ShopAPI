using E_Shop.Business.Abstract;
using E_Shop.DAL.Abstract.DataManagement;
using E_ShopAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Business.Concrete
{
    public class OrderManager : IOrderService
    {
       
        
            private readonly IUnitOfWork _uow;

            public OrderManager(IUnitOfWork uow)
            {
                _uow = uow;
            }
            public async Task<Order> GetAsync(Expression<Func<Order, bool>> Filter, params string[] IncludeProperties)
            {
                return await _uow.OrderRepository.GetAsync(Filter, IncludeProperties);
            }

            public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> Filter = null, params string[] IncludeProperties)
            {
                return await _uow.OrderRepository.GetAllAsync(Filter, IncludeProperties);
            }

            public async Task<Order> AddAsync(Order Entity)
            {

                await _uow.OrderRepository.AddAsync(Entity);
                await _uow.SaveChangeAsync();
                return Entity;

            }

            public async Task UpdateAsync(Order Entity)
            {
                await _uow.OrderRepository.UpdateAsync(Entity);
                await _uow.SaveChangeAsync();
            }

            public async Task RemoveAsync(Order Entity)
            {
                await _uow.OrderRepository.RemoveAsync(Entity);
                await _uow.SaveChangeAsync();
            }

            public async Task OrderAddV1(Order order, List<OrderDetail> orderDetails)
            {

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.Order = order;
                    await _uow.OrderDetailRepository.AddAsync(orderDetail);
                }

                await _uow.OrderRepository.AddAsync(order);

                await _uow.SaveChangeAsync();
            }
        }
    
    }
