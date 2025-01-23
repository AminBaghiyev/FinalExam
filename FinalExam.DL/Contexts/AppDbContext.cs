using FinalExam.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinalExam.DL.Contexts;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "8aad637d-42e5-4586-a140-697cd3ee8498", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "792af7b1-45f7-4238-b547-107355540960", Name = "User", NormalizedName = "USER" }
        );
        #endregion

        #region Admin
        IdentityUser admin = new()
        {
            Id = "be30629f-0508-461a-8fa1-0e905705e1f5",
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<IdentityUser> hasher = new();
        admin.PasswordHash = hasher.HashPassword(admin, "admin123");
        builder.Entity<IdentityUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "8aad637d-42e5-4586-a140-697cd3ee8498" }
        );
        #endregion

        base.OnModelCreating(builder);
    }
}
