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

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public Task Save(Contact contact)
        {
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task<ICollection<Contact>> GetAll()
        {
             return new Task<ICollection<Contact>>( ()=> _contacts.ToList());
        }
    }
}
