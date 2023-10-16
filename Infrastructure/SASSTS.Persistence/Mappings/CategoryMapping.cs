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
    public class CategoryMapping : DeletetableEntityMapping<Category>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasColumnName("CATEGORY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);

            builder.ToTable("CATEGORIES");
        }
    }
}
