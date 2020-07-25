using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace UI.WPF.ContactManager
{
    public interface IContactServiceAdapter
    {
        Task AddNewContactAsync(ContactUi contactUi);

        Task<ICollection<ContactUi>> GetAllContactsAsync();

    }
}