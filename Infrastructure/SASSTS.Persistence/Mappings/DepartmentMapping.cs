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
    public class DepartmentMapping : DeletetableEntityMapping<Department>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.DepartmentManagerId)
                .IsRequired(false)
                .HasColumnName("DEPARTMENT_MANAGER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.CompanyId)
                 .IsRequired()
                 .HasColumnName("COMPANY_ID")
                 .HasColumnOrder(3);

            builder.Property(x => x.DepartmentManagerName)
                .IsRequired(false)
                .HasColumnName("DEPARTMENT_MANAGER_NAME")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(4);

            builder.Property(x => x.DepartmentName)
                .IsRequired()
                .HasColumnName("DEPARTMENT_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(5);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(6);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("DEPARTMENT_COMPANY_COMPANY_ID");

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.DepartmentManagerId)
                .HasConstraintName("DEPARTMENT_CUSTOMER_CUSTOMER_ID");

            builder.ToTable("DEPARTMENTS");
        }
    }
}
