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
    public class CompanyMapping : DeletetableEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyManagerId)
                .IsRequired(false)
                .HasColumnName("COMPANY_MANAGER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.CompanyManagerName) 
                .IsRequired(false)
                .HasColumnName("COMPANY_MANAGER_NAME")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder (3);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(4);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.CompanyManagerId)
                .HasConstraintName("COMPANY_CUSTOMER_CUSTOMER_ID");

            builder.ToTable("COMPANIES");
        }
    }
}
