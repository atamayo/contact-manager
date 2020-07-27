using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Persistence.Tests
{
    public class InMemorySqlServerContactRepositoryTests
    {
        private IContactRepository _sqlContactRepository;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("ContactsInMemory");

            var dbFactory = new DbContextFactory(builder.Options);
            _sqlContactRepository = new SqlServerContactRepository(dbFactory);
            
        }

        [Test]
        public async Task AddContactAsync()
        {
            var contact = new Contact();

            await _sqlContactRepository.AddAsync(contact);

            Assert.AreEqual(1, contact.Id);
        }
    }
}