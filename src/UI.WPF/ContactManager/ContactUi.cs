using System;
using GalaSoft.MvvmLight;

namespace UI.WPF.ContactManager
{
    public class ContactUi : ObservableObject
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _mobilePhone;
        private string _email;


        public int Id
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
            set
            {
                _mobilePhone = value;
                RaisePropertyChanged(nameof(MobilePhone));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }
    }
}
