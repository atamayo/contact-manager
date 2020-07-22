using UI.WPF.ContactManager;


namespace UI.WPF
{
    class MainViewModel  
    {
        public  IContactsViewModel ContactsViewModel { get; }

        public MainViewModel(IContactsViewModel contactsViewModel)
        {
            ContactsViewModel = contactsViewModel;
        }
    }
}
