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
    public class WholesalerMapping : DeletetableEntityMapping<Wholesaler>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.Property(x => x.WholesalerName)
                .IsRequired()
                .HasColumnName("WHOLESALER_NAME")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(2);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("PHONE")
                .HasColumnType("nvarchar(13)")
                .HasColumnOrder(3);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("ADDRESS")
                .HasColumnType("nvarchar(500)")
                .HasColumnOrder(4);

            builder.ToTable("WHOLESALER");
        }
    }
}
