using System.Threading.Tasks;

namespace UI.WPF.ContactManager
{
    public interface IContactCreationServiceAdapter
    {
        Task AddNewAsync(ContactUi contactUi);
    }
}