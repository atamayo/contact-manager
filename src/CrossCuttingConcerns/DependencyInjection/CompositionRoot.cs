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
        readonly ContactContext _context;
        public CompositionRoot()
        {
           _context = new ContactContext();
        }
        
        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();
        }

        public  void Bootstrap()
        { 
           _context.Database.EnsureCreated();
        }
    }
}
