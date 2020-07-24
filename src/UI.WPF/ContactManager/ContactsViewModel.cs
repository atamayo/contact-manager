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
        private readonly IContactReaderService _contactReaderService;
        public ObservableCollection<ContactUi> ContactsCollection { get;  }
        public ICommand NewContactCommand { get; }

        public event Action NewContactRequested = delegate { };

        public ContactsViewModel(IContactReaderService contactReaderService)
       {
           _contactReaderService = contactReaderService;
           ContactsCollection = new ObservableCollection<ContactUi>();

           NewContactCommand = new RelayCommand(OnNewContact);
       }

        private void OnNewContact()
        {
            NewContactRequested();
        }

        public void LoadContacts()
        {
         
        }
    }
}
