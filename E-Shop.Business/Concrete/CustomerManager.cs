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
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitOfWork _uow;

        public CustomerManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CustomerRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.CustomerRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Customer> AddAsync(Customer Entity)
        {
            await _uow.CustomerRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task UpdateAsync(Customer Entity)
        {
            await _uow.CustomerRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task RemoveAsync(Customer Entity)
        {
            await _uow.CustomerRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
