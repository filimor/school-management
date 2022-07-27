using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Birthday).IsRequired();
        builder.Property(s => s.Gender).IsRequired();
        builder.Property(s => s.SkinColor).IsRequired();
        builder.HasOne<Address>().WithOne(a => a.Student).HasForeignKey<Student>(s => s.AddressId);
    }
}
