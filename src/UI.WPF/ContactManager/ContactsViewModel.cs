using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services.ContactManager;

namespace UI.WPF.ContactManager
{
    class ContactsViewModel : ViewModelBase, IContactsViewModel
    {
        private readonly IContactServiceAdapter _contactServiceAdapter;
        public ObservableCollection<ContactUi> ContactsCollection { get;  }
        public ICommand NewContactCommand { get; }

        public event Action NewContactRequested = delegate { };

       public ContactsViewModel(IContactServiceAdapter contactServiceAdapter)
       {
           _contactServiceAdapter = contactServiceAdapter;
           ContactsCollection = new ObservableCollection<ContactUi>();

           NewContactCommand = new RelayCommand(OnNewContact);
       }

        private void OnNewContact()
        {
            NewContactRequested();
        }

        public async void LoadContacts()
        {
            var contacts = await _contactServiceAdapter.GetAllContactsAsync();

            ContactsCollection.Clear();
            foreach (var contactUi in contacts)
            {
                ContactsCollection.Add(contactUi);  
            }
        }
    }
}
