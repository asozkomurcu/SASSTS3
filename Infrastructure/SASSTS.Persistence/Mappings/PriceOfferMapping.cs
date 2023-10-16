using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Persistence.Mappings
{
    public class PriceOfferMapping : DeletetableEntityMapping<PriceOffer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<PriceOffer> builder)
        {
            builder.Property(x => x.PurchaseRequestId)
                .IsRequired()
                .HasColumnName("PURCHASE_REQUEST_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(4);

            builder.Property(x => x.WholesalerId)
                .IsRequired()
                .HasColumnName("WHOLESALER_ID")
                .HasColumnOrder(5);

            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasColumnName("CUSTOMER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(6);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("PRODUCT_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(7);

            builder.Property(x => x.WholesalerName)
                .IsRequired()
                .HasColumnName("WHOLESALER_NAME")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(8);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("AMOUNT")
                .HasColumnOrder(9);

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnName("UNIT_PRICE")
                .HasColumnOrder(10);

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnName("TOTAL_PRICE")
                .HasColumnOrder(11);

            builder.Property(x => x.DeliveryDate)
                .IsRequired()
                .HasColumnName("DELIVERY_DATE")
                .HasColumnOrder(12);

            builder.HasOne(x => x.PurchaseRequest)
                .WithMany(x => x.PriceOffers)
                .HasForeignKey(x => x.PurchaseRequestId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("PRICE_OFFER_PURCHASE_REQUEST_PURCHASE_REQUEST_ID");

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.PriceOffers)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("PRICE_OFFER_CUSTOMER_CUSTOMER_ID");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.PriceOffers)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("PRICE_OFFER_PRODUCT_PRODUCT_ID");

            builder.HasOne(x => x.Wholesaler)
                .WithMany(x => x.PriceOffers)
                .HasForeignKey(x => x.WholesalerId)
                .HasConstraintName("PRICE_OFFER_WHOLESALER_WHOLESALER_ID");

            builder.ToTable("PRICE_OFFERS");
        }
    }
}
