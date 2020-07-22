using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace CrossCuttingConcerns.DependencyInjection
{
    public class CompositionRoot
    {
        public void ComposeApplication(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
