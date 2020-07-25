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
     
        public CompositionRoot()
        {
        }
        
        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();
            
        }

        public void Bootstrap()
        {
            using (var context = new ContactManagerDbContext())
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
