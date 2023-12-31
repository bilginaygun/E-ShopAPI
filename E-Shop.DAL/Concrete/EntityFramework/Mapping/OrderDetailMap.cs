﻿using E_Shop.DAL.Concrete.EntityFramework.Mapping.BaseMap;
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
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasOne(q => q.Product).WithMany(q => q.OrderDetails).HasForeignKey(q => q.OrderID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
