using System.Threading.Tasks;
using Domain;
using NUnit.Framework;

namespace Persistence.Tests
{
    public class RealDatabaseSqlServerContactRepositoryTests
    {
        private IContactRepository _sqlContactRepository;

        [SetUp]
        public void Setup()
        {
            string cnnString =
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Initial Catalog = ContactsTests;";

            var dbFactory = new DbContextFactory(cnnString);
            _sqlContactRepository = new SqlServerContactRepository(dbFactory);

            using (var context = dbFactory.Create())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
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