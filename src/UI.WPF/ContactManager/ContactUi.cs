using System;
using GalaSoft.MvvmLight;

namespace UI.WPF.ContactManager
{
    class ContactUi : ObservableObject
    {
        private Guid _id;
        private string _name;
        private string _surname;
        private string _mobilePhone;
        private string _email;


        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                RaisePropertyChanged(nameof(Surname));
            }
        }

        public string MobilePhone
        {
            get => _mobilePhone;
            set => _mobilePhone = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }
}
