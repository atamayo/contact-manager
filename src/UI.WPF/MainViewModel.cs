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
            ContactsViewModel.EditContactRequested += OnContactEditRequested;

            ContactDetailViewModel = contactDetailViewModel;
            ContactDetailViewModel.CancelRequested += OnCancelRequested;
            ContactDetailViewModel.SaveCompleted += OnSaveCompleted;
        }

      

        public IContactsViewModel ContactsViewModel { get; }
        public IContactDetailViewModel ContactDetailViewModel { get; }
        public IViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));

            }
        }

        private void OnContactEditRequested(ContactUi contactUi)
        {
            ContactDetailViewModel.EditMode = true;
            ContactDetailViewModel.Contact = contactUi;
            PerformNavigation(Views.DetailsContactView);
        }


        private void OnSaveCompleted()
        {
            PerformNavigation(Views.ContactsView);
        }


        private void OnCancelRequested()
        {
            PerformNavigation(Views.ContactsView);
        }

        private void OnNewContactRequested()
        {
            ContactDetailViewModel.EditMode = false;
            ContactDetailViewModel.Contact = new ContactUi();
            PerformNavigation(Views.DetailsContactView);
        }

        private void PerformNavigation(Views views)
        {
            switch (views)
            {
                case  Views.DetailsContactView:
                    CurrentViewModel = ContactDetailViewModel;
                    break;

                case Views.ContactsView:
                    CurrentViewModel = ContactsViewModel;
                    break;
            }
        }
    }
}
