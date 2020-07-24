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
        readonly ContactManagerDbContext _managerDbContext;
        public CompositionRoot()
        {

            
           _managerDbContext = new ContactManagerDbContext();
        }
        
        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();
            builder.Register(c=>_managerDbContext);
        }

        public  void Bootstrap()
        { 
           _managerDbContext.Database.EnsureCreated();
        }
    }
}
