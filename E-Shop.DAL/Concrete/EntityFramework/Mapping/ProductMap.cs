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
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Name).HasMaxLength(1000).IsRequired();
            builder.HasOne(q => q.Category).WithMany(x => x.Products).HasForeignKey(q => q.CategoryID).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
