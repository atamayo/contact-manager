using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
    public sealed class ContactManagerDbContext : DbContext
    {
        public ContactManagerDbContext()
        {
            // disable tracking to improve performance since is not used.
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options)
        : base(options)
        {
            
            
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Initial Catalog = Contacts;");
            
        }
    }
}