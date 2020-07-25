using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IContactRepository
    {
       Task AddAsync(Contact contact);
       Task EditAsync(Contact contact);
       Task DeleteAsync(int id);
       Task<ICollection<Contact>> GetAllAsync();
       Task<ICollection<Contact>> SearchAsync(string searchText);
    }
}