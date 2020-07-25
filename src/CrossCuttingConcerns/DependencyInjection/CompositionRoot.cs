using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
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

        public  void Bootstrap()
        {
            using (var context = new ContactManagerDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
