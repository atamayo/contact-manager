using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public sealed class ContactManagerDbContext : DbContext
    {

        public static readonly ILoggerFactory DebuggerLoggerFactory =
            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information).AddDebug();
            });


        public ContactManagerDbContext()
        {
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
            optionsBuilder
                .UseLoggerFactory(DebuggerLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Initial Catalog = Contacts;");
            
        }
    }
}