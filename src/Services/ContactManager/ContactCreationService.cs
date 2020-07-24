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

        public Task AddNewAsync(Contact contact)
        {

            _contactRepository.Save(contact);

            return Task.CompletedTask;
        }
    }
}
