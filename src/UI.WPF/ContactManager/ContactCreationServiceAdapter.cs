using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Services.ContactManager;

namespace UI.WPF.ContactManager
{
    class ContactCreationServiceAdapter : IContactCreationServiceAdapter
    {
        private readonly IContactCreationService _contactCreationService;

        public ContactCreationServiceAdapter(IContactCreationService contactCreationService)
        {
            _contactCreationService = contactCreationService;
        }

        public async Task AddNewAsync(ContactUi contactUi)
        {
            var contactDomain = MapToDomain(contactUi);
            await _contactCreationService.AddNewAsync(contactDomain);
        }

        private Contact MapToDomain(ContactUi contactUi)
        {
            return new Contact
            {
                Id = contactUi.Id,
                Name = contactUi.Name,
                Surname = contactUi.Surname,
                MobilePhone = contactUi.MobilePhone,
                Email = contactUi.Email
            };
        }
    }
}
