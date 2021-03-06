﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Services.ContactManager;
using System.Linq;

namespace UI.WPF.ContactManager
{
    class ContactServiceAdapter : IContactServiceAdapter
    {
        private readonly IContactCreationService _contactCreationService;
        private readonly IContactReaderService _contactReaderService;

        public ContactServiceAdapter(IContactCreationService contactCreationService, IContactReaderService contactReaderService)
        {
            _contactCreationService = contactCreationService;
            _contactReaderService = contactReaderService;
        }

        public async Task AddNewContactAsync(ContactUi contactUi)
        {
            var contactDomain = MapToDomain(contactUi);
            await _contactCreationService.AddNewAsync(contactDomain);
        }

        public async Task EditContactAsync(ContactUi contactUi)
        {
            var contactDomain = MapToDomain(contactUi);
            await _contactCreationService.EditAsync(contactDomain);
        }
        public async Task DeleteContactByxIdAsync(int id)
        {
           await _contactCreationService.DeleteAsync(id);
        }

        public async Task<ICollection<ContactUi>> GetAllContactsAsync()
        {
            var domainContacts = await _contactReaderService.GetAllAsync();
           return domainContacts.Select(MapToUi).ToList();
        }

        public  async Task<ICollection<ContactUi>> SearchContactsAsync(string searchText)
        {
            var domainContacts = await _contactReaderService.SearchAsync(searchText);
            return domainContacts.Select(MapToUi).ToList();

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

        private ContactUi MapToUi(Contact contact)
        {
            return new ContactUi
            {
                Id = contact.Id,
                Name = contact.Name,
                Surname = contact.Surname,
                MobilePhone = contact.MobilePhone,
                Email = contact.Email
            };
        }
    }
}
