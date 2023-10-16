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
    public class AccountMapping : BaseEntityMapping<Account>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(3);

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("nvarchar(500)")
                .HasColumnOrder(4);

            builder.Property(x => x.LastLoginDate)
                .HasColumnName("LAST_LOGIN_DATE")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder.Property(x => x.LastUserIp)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("LAST_LOGIN_IP")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.CustomerId);


            builder.ToTable("ACCOUNTS");
        }
    }
}
