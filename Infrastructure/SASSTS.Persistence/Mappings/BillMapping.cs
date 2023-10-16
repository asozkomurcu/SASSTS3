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
    public class BillMapping : AuditableEntityMapping<Bill>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(x => x.WholesalerId)
                .IsRequired()
                .HasColumnName("WHOLESALER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.BillDate)
                .IsRequired()
                .HasColumnName("BILL_DATE")
                .HasColumnOrder(4);

            builder.Property(x => x.BillNumber)
                .IsRequired()
                .HasColumnName("BILL_NUMBER")
                .HasColumnType("nvarchar(16)")
                .HasColumnOrder(5);

            builder.Property(x => x.BillType)
                .IsRequired()
                .HasColumnName("BILL_TYPE")
                .HasColumnType("nvarchar(10)")
                .HasColumnOrder(6);

            builder.Property(x => x.WholesalerName)
                .IsRequired()
                .HasColumnName("WHOLESALER_NAME")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(7);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("PRODUCT_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(8);

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnName("UNIT_PRICE")
                .HasColumnOrder(9);

            builder.Property(x => x.KDV)
                .IsRequired()
                .HasColumnName("KDV")
                .HasColumnOrder(10);

            builder.Property(x => x.Discount)
                .HasColumnName("DISCOUNT")
                .HasColumnOrder(11);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("AMOUNT")
                .HasColumnOrder(12);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("PRICE")
                .HasColumnOrder(12);

            builder.Property(x => x.TotalUnitPrice)
                .IsRequired()
                .HasColumnName("TOTAL_UNIT_PRICE")
                .HasColumnOrder(13);

            builder.Property(x => x.TotalDiscount)
                .HasColumnName("TOTAL_DISCOUNT")
                .HasColumnOrder(14);

            builder.Property(x => x.TotalKDV)
                .IsRequired()
                .HasColumnName("TOTAL_KDV")
                .HasColumnOrder(15);

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnName("TOTAL_PRICE")
                .HasColumnOrder(16);

            builder.HasOne(x => x.Wholesaler)
                .WithMany(x => x.Bills)
                .HasForeignKey(x => x.WholesalerId)
                .HasConstraintName("BILL_WHOLESALER_WHOLESALER_ID");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Bills)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("BILL_PRODUCT_PRODUCT_ID");

            builder.ToTable("BILLS");
        }
    }
}
