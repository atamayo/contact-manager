using Autofac;
using GalaSoft.MvvmLight;
using UI.WPF.ContactManager;

namespace UI.WPF
{
    public class UiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

            }

            builder.RegisterType<ContactsViewModel>().As<IContactsViewModel>();

            builder.RegisterType<MainViewModel>();
        }
    }
}