using Autofac;
using GalaSoft.MvvmLight;
using UI.WPF.ContactManager;

namespace UI.WPF
{
    public class UiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactsViewModel>().As<IContactsViewModel>();
            builder.RegisterType<ContactDetailViewModel>().As<IContactDetailViewModel>();
            builder.RegisterType<ContactCreationServiceAdapter>().As<IContactCreationServiceAdapter>();
            builder.RegisterType<MainViewModel>();
        }
    }
}
