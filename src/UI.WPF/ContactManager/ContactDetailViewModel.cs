using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services.ContactManager;

namespace UI.WPF.ContactManager
{
    public class ContactDetailViewModel : ViewModelBase, IContactDetailViewModel
    {
        private readonly IContactServiceAdapter _contactServiceAdapter;
        private ContactUi _contactUi;
        public event Action CancelRequested;
        public event Action SaveCompleted;
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

        public bool EditMode { get; set; }

        public ContactDetailViewModel(IContactServiceAdapter contactServiceAdapter)
        {
            _contactServiceAdapter = contactServiceAdapter;
            CancelContactCommand = new RelayCommand(OnCancel);
            SaveContactCommand = new RelayCommand(OnSave);
        }

        private async void OnSave()
        {
            if (EditMode)
            {
                await _contactServiceAdapter.EditContactAsync(Contact);
            }
            else
            {
                await _contactServiceAdapter.AddNewContactAsync(Contact);
            }
            
            SaveCompleted?.Invoke();
        }

        private void OnCancel()
        {
           CancelRequested?.Invoke();
        }
    }
}