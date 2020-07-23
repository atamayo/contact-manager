using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UI.WPF.ContactManager
{
    public class ContactDetailViewModel : ViewModelBase, IContactDetailViewModel
    {
        public event Action CancelRequested = delegate { };
        public ICommand CancelCommand { get; }

        public ContactDetailViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnCancel()
        {
            CancelRequested();
        }
    }
}