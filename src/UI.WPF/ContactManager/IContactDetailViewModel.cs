using System;
using System.Windows.Input;

namespace UI.WPF.ContactManager
{
    public interface IContactDetailViewModel : IViewModelBase
    {
        event Action CancelRequested;
        ICommand CancelContactCommand { get; }

        ICommand SaveContactCommand { get; }

        ContactUi Contact { get; }
    }
}