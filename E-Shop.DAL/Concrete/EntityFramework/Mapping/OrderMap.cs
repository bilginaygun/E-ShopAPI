using E_Shop.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using E_ShopAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderMap : BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasOne(q => q.Customer).WithMany(q => q.Orders).HasForeignKey(q => q.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(q => q.OrderDetails).WithOne(q => q.Order).HasForeignKey(q => q.OrderID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
