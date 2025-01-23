using FinalExam.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.DL.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(e => e.Comment)
            .HasMaxLength(255)
            .IsRequired();
    }
}
