using Microsoft.EntityFrameworkCore;
using Service.Core.Persistence.Interfaces;
using System;

namespace Service.Core.Persistence
{
    public abstract class BaseSeeder : ISeeder
    {
        public abstract void Seed(DbContext dbContext, Guid domainId, Guid accountId);
    }
}
