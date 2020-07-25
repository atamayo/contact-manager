using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.ContactManager
{
   public class ContactReaderService : IContactReaderService
    {
        private readonly IContactRepository _contactRepository;

        public ContactReaderService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<ICollection<Contact>> GetAllAsync()
        {
           return await _contactRepository.GetAllAsync();
        }

        public async Task<ICollection<Contact>> SearchAsync(string searchText)
        {
            return await _contactRepository.SearchAsync(searchText);
        }
    }
}
