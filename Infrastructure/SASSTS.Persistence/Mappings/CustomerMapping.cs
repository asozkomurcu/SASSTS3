using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SASSTS.Domain.Entities;

namespace SASSTS.Persistence.Mappings
{
    public class CustomerMapping : DeletetableEntityMapping<Customer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.IdentityNumber)
                .IsRequired()
                .HasColumnName("IDENTITY_NUMBER")
                .HasColumnType("nvarchar(11)")
                .HasColumnOrder(2);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(3);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasColumnName("SURNAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(4);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(5);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("PHONE")
                .HasColumnType("nchar(11)")
                .HasColumnOrder(6);

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasColumnName("GENDER")
                .HasColumnOrder(7);

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("nvarchar(500)")
                .HasColumnOrder(8);

            builder.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnName("DEPARTMENT_ID")
                .HasColumnOrder(9);

            builder.Property(x => x.DepartmentName)
                .IsRequired()
                .HasColumnName("DEPARTMENT_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(10);

            builder.Property(x => x.Role)
                .IsRequired()
                .HasColumnName("ROLE")
                .HasColumnOrder(11);

            builder.Property(x => x.UserAuthorizations)
                .IsRequired(false)
                .HasColumnName("USER_AUTHORIZATION")
                .HasColumnOrder(12);


            builder.ToTable("CUSTOMERS");
        }
    }
}
