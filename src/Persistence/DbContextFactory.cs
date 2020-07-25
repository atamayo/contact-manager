using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContactManagerDbContext Create()
        {
            return new ContactManagerDbContext(_connectionString);
        }
    }
}
