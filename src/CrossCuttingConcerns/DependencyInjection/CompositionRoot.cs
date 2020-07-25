using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CrossCuttingConcerns.DataGenerator;
using Persistence;

namespace CrossCuttingConcerns.DependencyInjection
{
    public class CompositionRoot
    {
        private readonly string _connectionString;

        public CompositionRoot(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();

            builder.Register(f => new DbContextFactory(_connectionString)).As<IDbContextFactory>();

        }

        public void Bootstrap()
        {
            using (var context = new ContactManagerDbContext(_connectionString))
            {
                if (context.Database.EnsureCreated())
                {
                    var  randomContactGenerator = new RandomContactGenerator();
                    var contacts = randomContactGenerator.GenerateContacts(5000);
                    context.Contacts.AddRange(contacts);
                    context.SaveChanges();
                }
            }
        }
    }
}
