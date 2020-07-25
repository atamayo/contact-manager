using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IContactRepository
    {
       Contact GetById(int id);
       Task SaveAsync(Contact contact);
       Task<ICollection<Contact>> GetAllAsync();
    }
}