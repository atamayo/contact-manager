using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Contact;

namespace Services.ContactManager
{
   public class ContactReaderService : IContactReaderService
    {
        public Task<ICollection<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
