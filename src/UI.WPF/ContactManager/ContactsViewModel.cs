using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Services.ContactManager;

namespace UI.WPF.ContactManager
{
    class ContactsViewModel : ViewModelBase, IContactsViewModel
    {
        private readonly IContactReaderService _contactReaderService;
        public ObservableCollection<ContactUi> ContactsCollection { get;  }

       public ContactsViewModel(IContactReaderService contactReaderService)
       {
           _contactReaderService = contactReaderService;
           ContactsCollection = new ObservableCollection<ContactUi>();
       }

    }
}
