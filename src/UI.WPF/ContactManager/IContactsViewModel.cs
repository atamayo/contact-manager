using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UI.WPF.ContactManager
{
    public interface IContactsViewModel : IViewModelBase
    {
        ObservableCollection<ContactUi> ContactsCollection { get; }

        ICommand NewContactCommand { get; }

        event Action NewContactRequested;
    }
}