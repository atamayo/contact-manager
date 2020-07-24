using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
    public class ContactManagerDbContext : DbContext
    {
        public ContactManagerDbContext()
        {
            
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