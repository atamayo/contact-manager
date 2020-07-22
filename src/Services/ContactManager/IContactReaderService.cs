using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contact;

namespace Services.ContactManager
{
    public interface IContactReaderService      
    {
       Task<ICollection<Contact>> GetAllAsync();
    }
}