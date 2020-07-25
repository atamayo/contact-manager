using System;
using System.Collections.Generic;
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
        public ICommand EditContactCommand { get; }
        public ICommand DeleteContactCommand { get; }
        public ICommand SearchCommand { get; }
        public event Action NewContactRequested;
        public event Action<ContactUi> EditContactRequested;
        public bool RefreshContacts { get; set; } = true;

        public ContactsViewModel(IContactServiceAdapter contactServiceAdapter)
       {
           _contactServiceAdapter = contactServiceAdapter;
           ContactsCollection = new ObservableCollection<ContactUi>();

           NewContactCommand = new RelayCommand(OnNewContact);
           EditContactCommand = new RelayCommand<ContactUi>(OnEditContact);
           DeleteContactCommand = new RelayCommand<ContactUi>(OnDeleteContact);
           SearchCommand = new RelayCommand<string>(OnSearch);
       }

       public async void LoadContacts()
       {
           if (RefreshContacts)
           {
               var contacts = await _contactServiceAdapter.GetAllContactsAsync();
               LoadContacts(contacts);
           }
       }

       
       private void LoadContacts(ICollection<ContactUi> contacts)
       {
           ContactsCollection.Clear();
           foreach (var contactUi in contacts)
           {
               ContactsCollection.Add(contactUi);
           }
        }

       private async void OnSearch(string searchText)
       {
          var contacts =  await _contactServiceAdapter.SearchContactsAsync(searchText);
          LoadContacts(contacts);
        }

       private async void OnDeleteContact(ContactUi contactUi)
       {
           await _contactServiceAdapter.DeleteContactByxIdAsync(contactUi.Id);
           ContactsCollection.Remove(contactUi);
       }

       private void OnEditContact(ContactUi contactUi)
       {
           EditContactRequested?.Invoke(contactUi);
       }

       private void OnNewContact()
       {
           NewContactRequested?.Invoke();
       }


    }
}
