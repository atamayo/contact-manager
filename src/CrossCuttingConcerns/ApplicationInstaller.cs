using Autofac;
using CrossCuttingConcerns.DataGenerator;
using CrossCuttingConcerns.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace CrossCuttingConcerns
{
    public class ApplicationInstaller
    {

        private readonly ContextConfigurator _contextConfigurator;
        private readonly bool _useRealDatabase;
        private DbContextOptions _contextOptions;
        public ApplicationInstaller(string connectionString)
        {
            _useRealDatabase = true;
           _contextConfigurator = new ContextConfigurator(connectionString);
        }

        public ApplicationInstaller()
        {
            _useRealDatabase = false;
            _contextConfigurator = new ContextConfigurator();
        }

        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();
            
            _contextOptions = _useRealDatabase ? _contextConfigurator.CreateRealDbContextOptions() : _contextConfigurator.CreateInMemoryContextOptions("ContactManager");

            builder.Register(f => new DbContextFactory(_contextOptions))
                .As<IDbContextFactory>();
        }

        public void EnsureDatabaseCreation()
        {
            using (var context = new ContactManagerDbContext(_contextOptions))
            {
                if (context.Database.EnsureCreated())
                {
                    var randomContactGenerator = new RandomContactGenerator();
                    var contacts = randomContactGenerator.GenerateContacts(5000);
                    context.Contacts.AddRange(contacts);
                    context.SaveChanges();
                }
            }
        }
    }
}
