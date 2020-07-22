using System.Collections.ObjectModel;

namespace UI.WPF.ContactManager
{
    interface IContactsViewModel
    {
        ObservableCollection<ContactUi> ContactsCollection { get; }
    }
}