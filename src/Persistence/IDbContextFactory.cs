using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDbContextFactory 
    {
        ContactManagerDbContext Create();
    }
}