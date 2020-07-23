using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Services.ContactManager
{
    public interface IContactReaderService      
    {
       Task<ICollection<Contact>> GetAllAsync();
    }
}