using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Persistence.Mappings
{
    public class ProductMapping : DeletetableEntityMapping<Product>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.CategoryId)
                .IsRequired()
                .HasColumnName("CATEGORY_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("PRODUCT_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(3);

            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasColumnName("CATEGORY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(4);

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnOrder(3);

            builder.Property(x => x.UnitPrice)
                .HasColumnName("UNIT_PRICE")
                .HasColumnOrder(4);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("PRODUCT_CATEGORY_CATEGORY_ID");

            builder.ToTable("PRODUCTS");
        }
    }
}
