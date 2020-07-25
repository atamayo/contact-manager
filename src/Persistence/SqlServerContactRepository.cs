﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Domain;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class SqlServerContactRepository : IContactRepository
    {
        private readonly ContactManagerDbContext _contactManagerDbContext;

        public SqlServerContactRepository(ContactManagerDbContext contactManagerDbContext)
        {
            _contactManagerDbContext = contactManagerDbContext;
        }

        public Contact GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveAsync(Contact contact)
        {
            await _contactManagerDbContext.AddAsync(contact);

            await SaveDbContextChangesAsync();
        }

        private async Task SaveDbContextChangesAsync()
        {
            try
            {
                await _contactManagerDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<ICollection<Contact>> GetAllAsync()
        {
          return await _contactManagerDbContext.Contacts.ToListAsync();
        }
    }
}