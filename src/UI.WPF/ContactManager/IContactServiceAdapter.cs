using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace UI.WPF.ContactManager
{
    public interface IContactServiceAdapter
    {
        Task AddNewContactAsync(ContactUi contactUi);
        Task EditContactAsync(ContactUi contactUi);

        Task DeleteContactByxIdAsync(int id);

        Task<ICollection<ContactUi>> GetAllContactsAsync();
        Task<ICollection<ContactUi>> SearchContactsAsync(string searchText);
    }
}