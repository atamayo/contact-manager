using Autofac;
using CrossCuttingConcerns.DataGenerator;
using CrossCuttingConcerns.DependencyInjection;
using Persistence;

namespace CrossCuttingConcerns
{
    public class ApplicationInstaller
    {

        private readonly ContextConfigurator _contextConfigurator;

        public ApplicationInstaller(string connectionString)
        {
           _contextConfigurator = new ContextConfigurator(connectionString);
        }
        
        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();
            builder.Register(f => new DbContextFactory(_contextConfigurator.CreateDefaultOptions())).As<IDbContextFactory>();
        }

        public void EnsureDatabaseCreation()
        {
            using (var context = new ContactManagerDbContext(_contextConfigurator.CreateDefaultOptions()))
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
