using System;
using System.Collections.Generic;
using System.Text;
using CrossCuttingConcerns.DataGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace CrossCuttingConcerns.DataBase
{
    public class DataBaseConfigurator
    {
        private readonly string _connectionString;

        public static readonly ILoggerFactory DebuggerLoggerFactory =

            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information).AddDebug();
            });

        public DataBaseConfigurator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbContextOptions CreateOptions()
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseLoggerFactory(DebuggerLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(_connectionString);

            return builder.Options;
        }
    }
}
