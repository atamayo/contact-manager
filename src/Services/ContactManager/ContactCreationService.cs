using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.ContactManager
{
    public class ContactCreationService : IContactCreationService
    {
        private readonly IContactRepository _contactRepository;

        public ContactCreationService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddNewAsync(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
        }

        public async Task EditAsync(Contact contact)
        {
            await _contactRepository.EditAsync(contact);
        }
        public async Task DeleteAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }
    }
}
