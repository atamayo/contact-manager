using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
    public class ContactContext : DbContext
    {


        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Initial Catalog = Contacts;");
            
        }
    }
}