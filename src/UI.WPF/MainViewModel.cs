using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UI.WPF.ContactManager;

namespace UI.WPF
{
    class MainViewModel : ViewModelBase, IViewModelBase
    {
        private IViewModelBase _currentViewModel;

        public MainViewModel(IContactsViewModel contactsViewModel, IContactDetailViewModel contactDetailViewModel)
        {
            ContactsViewModel = contactsViewModel;
            CurrentViewModel = contactsViewModel;
            ContactsViewModel.NewContactRequested += OnNewContactRequested;

            ContactDetailViewModel = contactDetailViewModel;
            ContactDetailViewModel.CancelRequested += OnCancelRequested;
        }

        private void OnCancelRequested()
        {
            PerformNavigation("contactsView");
        }

        private void OnNewContactRequested()
        {
            PerformNavigation("newContactView");
        }

        private void PerformNavigation(string destination)
        {
            switch (destination)
            {
                case "newContactView":
                    CurrentViewModel = ContactDetailViewModel;
                    break;

                case "contactsView":
                    CurrentViewModel = ContactsViewModel;
                    break;
            }
        }


        public IContactsViewModel ContactsViewModel { get; }
        public IContactDetailViewModel ContactDetailViewModel { get; private set;}

        public IViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));

            }
        }

       
    }
}
