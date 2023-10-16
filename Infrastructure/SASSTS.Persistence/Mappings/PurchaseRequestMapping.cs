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
    public class PurchaseRequestMapping : DeletetableEntityMapping<PurchaseRequest>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<PurchaseRequest> builder)
        {
            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.RequestCustomerId)
                .IsRequired()
                .HasColumnName("REQUEST_CUSTOMER_ID")
                .HasColumnOrder(3);
            
            builder.Property(x => x.OfferCustomerId)
                .IsRequired(false)
                .HasColumnName("OFFER_CUSTOMER_ID")
                .HasColumnOrder(4);
            
            builder.Property(x => x.ApprovingCustomerId)
                .IsRequired(false)
                .HasColumnName("APPROVING_CUSTOMER_ID")
                .HasColumnOrder(5);

            builder.Property(x => x.RequestCustomerName)
                .IsRequired()
                .HasColumnName("REQUEST_CUSTOMER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(6);

            builder.Property(x => x.OfferCustomerName)
                .IsRequired(false)
                .HasColumnName("OFFER_CUSTOMER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(7);

            builder.Property(x => x.ApprovingCustomerName)
                .IsRequired(false)
                .HasColumnName("APPROVING_CUSTOMER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(8);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("PRODUCT_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(9);

            builder.Property(x => x.ProductDescription)
                .IsRequired()
                .HasColumnName("PRODUCT_DESCRIPTION")
                .HasColumnType("nvarchar(500)")
                .HasColumnOrder(10);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("AMOUNT")
                .HasColumnOrder(11);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnName("STATUS")
                .HasColumnOrder(12);

            builder.Property(x => x.PriceOfferId)
                .IsRequired(false)
                .HasColumnName("PRICE_OFFER")
                .HasColumnOrder(6);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.PurchaseRequests)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("PURCHASE_REQUEST_PRODUCT_PRODUCT_ID");

            builder.HasOne(x => x.Customer)
               .WithMany(x => x.PurchaseRequests)
               .HasForeignKey(x => x.RequestCustomerId)
               .HasConstraintName("PURCHASE_REQUEST_CUSTOMER_REQUEST_CUSTOMER_ID");

            builder.HasOne(x => x.PriceOffer)
                .WithMany(x => x.PurchaseRequests)
                .HasForeignKey(x => x.PriceOfferId)
                .HasConstraintName("PURCHASE_REQUEST_PRICE_OFFER_PRICE_OFFER_ID");

            builder.ToTable("PURCHASE_REQUEST");
        }
    }
}
