using Autofac;
using CrossCuttingConcerns.DependencyInjection;
using GalaSoft.MvvmLight;

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

            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

                compositionRoot.Bootstrap();
            }
            
        }

        public MainViewModel Main => Container.Resolve<MainViewModel>();
    }
}