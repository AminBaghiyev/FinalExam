using FinalExam.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.DL.Configurations;

public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
{
    public void Configure(EntityTypeBuilder<Profession> builder)
    {
        builder
            .HasMany(e => e.Customers)
            .WithOne(e => e.Profession)
            .HasForeignKey(e => e.ProfessionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder
            .Property(e => e.Title)
            .HasMaxLength(50)
            .IsRequired();
    }
}
