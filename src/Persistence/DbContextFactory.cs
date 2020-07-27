using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions _options;

        public DbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ContactManagerDbContext Create()
        {
            return new ContactManagerDbContext(_options);
        }
    }
}
