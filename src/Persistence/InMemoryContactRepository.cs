using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Domain;
using System.Linq;

namespace Persistence
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly ICollection<Contact> _contacts;

        public InMemoryContactRepository()  
        {
            _contacts = new Collection<Contact>();
        }

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Save(Contact contact)
        {
            _contacts.Add(contact);
        }

        public ICollection<Contact> GetAll()
        {
            return _contacts;
        }
    }
}
