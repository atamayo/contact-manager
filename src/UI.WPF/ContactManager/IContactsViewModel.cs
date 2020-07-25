using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UI.WPF.ContactManager
{
    public interface IContactsViewModel : IViewModelBase
    {
        ObservableCollection<ContactUi> ContactsCollection { get; }
        ICommand NewContactCommand { get; }
        ICommand EditContactCommand { get; }
        ICommand DeleteContactCommand { get; }
        event Action NewContactRequested;
        event Action<ContactUi> EditContactRequested;
        void LoadContacts();
    }
}
