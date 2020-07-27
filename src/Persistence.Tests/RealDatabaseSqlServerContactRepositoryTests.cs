using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Persistence.Tests
{
    public class RealDatabaseSqlServerContactRepositoryTests
    {
        private IContactRepository _sqlContactRepository;

        public static readonly ILoggerFactory ConsoleLoggerFactory =

            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information).AddConsole();
            });

        [SetUp]
        public void Setup()
        {
            string cnnString =
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Initial Catalog = ContactsTests;";

            var builder = new DbContextOptionsBuilder()
                .UseLoggerFactory(ConsoleLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(cnnString);

            var dbFactory = new DbContextFactory(builder.Options);
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