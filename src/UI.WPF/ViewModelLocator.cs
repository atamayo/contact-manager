using Autofac;
using CrossCuttingConcerns;
using GalaSoft.MvvmLight;

namespace UI.WPF
{
    class ViewModelLocator
    {
        private static IContainer Container { get; set; }

        public ViewModelLocator()
        {
            //var applicationInstaller = new ApplicationInstaller(
            //    @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Initial Catalog = ContactManager;");

            var applicationInstaller = new ApplicationInstaller();

            var builder = new ContainerBuilder();
            
            applicationInstaller.ComposeApplication(builder);

            builder.RegisterModule<UiModule>();

            Container = builder.Build();

            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

                applicationInstaller.EnsureDatabaseCreation();
            }
            
        }

        public MainViewModel Main => Container.Resolve<MainViewModel>();
    }
}