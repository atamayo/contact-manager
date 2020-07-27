using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public sealed class ContactManagerDbContext : DbContext
    {
    
        public ContactManagerDbContext(DbContextOptions options)
        : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
    }
}