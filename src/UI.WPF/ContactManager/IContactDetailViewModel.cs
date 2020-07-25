using System;
using System.Windows.Input;

namespace UI.WPF.ContactManager
{
    public interface IContactDetailViewModel : IViewModelBase
    {
        event Action CancelRequested;
        event Action SaveCompleted;
        ICommand CancelContactCommand { get; }
        ICommand SaveContactCommand { get; }
        ContactUi Contact { get; set; }
        bool EditMode { get; set; }
    }
}
