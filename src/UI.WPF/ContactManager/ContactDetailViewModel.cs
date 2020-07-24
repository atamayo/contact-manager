using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services.ContactManager;

namespace UI.WPF.ContactManager
{
    public class ContactDetailViewModel : ViewModelBase, IContactDetailViewModel
    {
        private readonly IContactCreationServiceAdapter _contactCreationServiceAdapter;
        private ContactUi _contactUi;
        public event Action CancelRequested;
        public ICommand CancelContactCommand { get; }

        public ICommand SaveContactCommand { get; }

        public ContactUi Contact
        {
            get => _contactUi;
            set
            {
                _contactUi = value;
                RaisePropertyChanged(nameof(ContactUi));
            }
        }

        public ContactDetailViewModel(IContactCreationServiceAdapter contactCreationServiceAdapter)
        {
            _contactCreationServiceAdapter = contactCreationServiceAdapter;
            CancelContactCommand = new RelayCommand(OnCancel);
            SaveContactCommand = new RelayCommand(OnSave);
            _contactUi = new ContactUi();
        }

        private async void OnSave()
        {
           await _contactCreationServiceAdapter.AddNewAsync(Contact);
        }

        private void OnCancel()
        {
           CancelRequested?.Invoke();
        }
    }
}