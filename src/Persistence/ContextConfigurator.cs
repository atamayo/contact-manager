using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public class ContextConfigurator
    {
        private readonly string _connectionString;

        public static readonly ILoggerFactory DebuggerLoggerFactory =

            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information).AddDebug();
            });

        public ContextConfigurator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContextConfigurator()
        {
            
        }

        public DbContextOptions CreateInMemoryContextOptions(string databaseName)
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseLoggerFactory(DebuggerLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName);

            return builder.Options;
        }

        public DbContextOptions CreateRealDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseLoggerFactory(DebuggerLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(_connectionString);

            return builder.Options;
        }
    }
}
