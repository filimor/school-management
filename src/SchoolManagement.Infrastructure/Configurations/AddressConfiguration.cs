using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Street).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Number).HasMaxLength(10).IsRequired();
        builder.Property(a => a.District).HasMaxLength(100).IsRequired();
        builder.Property(a => a.City).HasMaxLength(100).IsRequired();
        builder.Property(a => a.State).HasMaxLength(2).IsRequired();
        builder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired();
    }
}
