using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Domain.Contact;
using System.Linq;

namespace Persistence.Contact
{
    class InMemoryContactRepository : IContactRepository
    {
        private readonly ICollection<IContact> _contacts;

        public InMemoryContactRepository()  
        {
            _contacts = new Collection<IContact>();
        }

        public IContact GetById(Guid id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Save(IContact contact)
        {
            _contacts.Add(contact);
        }

        public ICollection<IContact> GetAll()
        {
            return _contacts;
        }
    }
}
