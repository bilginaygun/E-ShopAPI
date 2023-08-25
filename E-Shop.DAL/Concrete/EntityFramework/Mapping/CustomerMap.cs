using E_Shop.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using E_ShopAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.DAL.Concrete.EntityFramework.Mapping
{
    public class CustomerMap : BaseMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(q => q.FirstName).HasMaxLength(200);
            builder.Property(q => q.LastName).HasMaxLength(200).IsRequired();
            builder.Property(q => q.Customername).HasMaxLength(200).IsRequired();
            builder.Property(q => q.Password).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(100).IsRequired();
            builder.Property(q => q.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(q => q.Adress).IsRequired();
        }
    }
}
