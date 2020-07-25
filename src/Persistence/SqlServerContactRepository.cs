using System;
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
        private readonly IDbContextFactory _dbContextFactory;

        public SqlServerContactRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddAsync(Contact contact)
        {
            await using (var context = _dbContextFactory.Create())
            {
                await context.AddAsync(contact);

                await SaveDbContextChangesAsync(context);
            }
        }
        public async Task EditAsync(Contact contact)
        {
            await using (var context = _dbContextFactory.Create())
            {
                var dbContact = await context.Contacts.FindAsync(contact.Id);

                context.Contacts.Attach(dbContact);

                dbContact.Name = contact.Name;
                dbContact.Surname = contact.Surname;
                dbContact.MobilePhone = contact.MobilePhone;
                dbContact.Email = contact.Email;

                await SaveDbContextChangesAsync(context);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await using (var context = _dbContextFactory.Create())
            {
                var dbContact = await context.Contacts.FindAsync(id);
                context.Contacts.Attach(dbContact);
                context.Remove(dbContact);
                await SaveDbContextChangesAsync(context);
            }
        }

        private async Task SaveDbContextChangesAsync(DbContext context)
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<ICollection<Contact>> GetAllAsync()
        {
            await using (var context = _dbContextFactory.Create())
            {
                return await context.Contacts.ToListAsync();
            }
        }

        public async Task<ICollection<Contact>> SearchAsync(string searchText)
        {
            var text = searchText.ToLower().Trim();

            await using (var context = _dbContextFactory.Create())
            {
                var contacts = await context.Contacts
                    .Where(contact =>
                        EF.Functions.Like(contact.Name, $"%{text}%") ||
                        EF.Functions.Like(contact.Surname, $"%{text}%") ||
                        EF.Functions.Like(contact.MobilePhone, $"%{text}%") ||
                        EF.Functions.Like(contact.Email, $"%{text}%")
                    )
                    .ToListAsync();

                return contacts;
            }
        }
    }
}
