using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Customer.Domain.Entities;

namespace MS.Customer.Infra.DataAccess.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.CustomerId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();


            builder.Property(x => x.Password)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnType("VARCHAR(30)")
                .IsRequired();


            builder.Property(x => x.Cpf)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Generous)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("int");

            builder.Property(x => x.IsActive).IsRequired();

        }
    }
}
