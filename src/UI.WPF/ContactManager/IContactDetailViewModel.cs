using System;
using System.Windows.Input;

namespace UI.WPF.ContactManager
{
    public interface IContactDetailViewModel : IViewModelBase
    {
        event Action CancelRequested;
        ICommand CancelCommand { get; }
    }
}