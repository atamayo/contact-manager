
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Domain;
using Persistence;

namespace CrossCuttingConcerns.DependencyInjection
{
    internal class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<InMemoryContactRepository>().As<IContactRepository>().SingleInstance();

            builder.RegisterType<SqlServerContactRepository>().As<IContactRepository>();
        }
    }
}
