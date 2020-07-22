
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Domain.Contact;
using Persistence.Contact;

namespace CrossCuttingConcerns.DependencyInjection
{
    internal class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<InMemoryContactRepository>().As<IContactRepository>();
        }
    }
}
