using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly ConcurrentBag<Contact> _contacts;

        public InMemoryContactRepository()  
        {
            _contacts = new ConcurrentBag<Contact>();
        }

        public Task AddAsync(Contact contact)
        {
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task EditAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Contact>> GetAllAsync()
        {
             return new Task<ICollection<Contact>>( ()=> _contacts.ToList());
        }
    }
}
