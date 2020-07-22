using Autofac;
using CrossCuttingConcerns.DependencyInjection;

namespace UI.WPF
{
    class ViewModelLocator
    {
        private static IContainer Container { get; set; }

        public ViewModelLocator()
        {
            var compositionRoot = new CompositionRoot();
            var builder = new ContainerBuilder();
            compositionRoot.ComposeApplication(builder);

            builder.RegisterModule<UiModule>();

            Container = builder.Build();
        }

        public MainViewModel Main => Container.Resolve<MainViewModel>();
    }
}