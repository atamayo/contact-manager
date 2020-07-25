using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IContactRepository
    {
       Task AddAsync(Contact contact);
       Task EditAsync(Contact contact);
       Task<ICollection<Contact>> GetAllAsync();
    }
}