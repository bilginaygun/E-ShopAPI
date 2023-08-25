using E_Shop.DAL.Abstract.DataManagement;
using E_Shop.DAL.Abstract;
using E_ShopAPI.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shop.DAL.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Http;

namespace E_Shop.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly E_ShopContext e_ShopContext;
        private readonly IHttpContextAccessor _contextAccessor;
        

        public EfUnitOfWork(E_ShopContext e_ShopContext, IHttpContextAccessor contextAccessor)
        {
            this.e_ShopContext = e_ShopContext;
            _contextAccessor = contextAccessor;
            CategoryRepository = new EfCategoryRepository(e_ShopContext);
            CustomerRepository = new EfCustomerRepository(e_ShopContext);
            OrderRepository = new EfOrderRepository(e_ShopContext);
            ProductRepository = new EfProductRepository(e_ShopContext);
            OrderDetailRepository = new EfOrderDetailRepository(e_ShopContext);
        }

       

        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in e_ShopContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.AddedIPV4Adress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Adress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }

                    item.Entity.IsDeleted = false;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Adress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
            }

            return await e_ShopContext.SaveChangesAsync();
        }
    }
}
