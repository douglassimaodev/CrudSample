using CrudSample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.HasAnnotation("MySql:CharSet", "utf8mb4");
            //builder.UseGuidCollation("ascii_general_ci");

            base.OnModelCreating(builder);

            builder.Entity<Client>().HasKey(x => x.Id);

            builder.Entity<Client>().Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Entity<Client>().Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

            builder.Entity<Client>().Property(x => x.Email)
               .HasMaxLength(200)
               .IsUnicode(false);

            builder.Entity<Client>().Property(x => x.Phone)
              .HasMaxLength(200)
              .IsUnicode(false);

            builder.Entity<Client>().Property(x => x.Address)
              .HasMaxLength(200)
              .IsUnicode(false);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}