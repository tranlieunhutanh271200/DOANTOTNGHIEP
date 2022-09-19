using Microsoft.EntityFrameworkCore;
using System;

namespace Service.Core.Persistence.Interfaces
{
    public interface ISeeder
    {
        void Seed(DbContext dbContext, Guid domainId, Guid accountId);
    }
}
