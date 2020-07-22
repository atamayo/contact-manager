using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Services.ContactManager;

namespace CrossCuttingConcerns.DependencyInjection
{
    internal class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactReaderService>().As<IContactReaderService>();
        }
    }
}
