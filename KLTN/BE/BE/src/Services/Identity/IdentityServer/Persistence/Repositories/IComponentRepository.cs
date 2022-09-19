using Service.Core.Models.Identities;
using Service.Core.Persistence.Interfaces;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.Repositories
{
    public interface IComponentRepository : IAsyncRepository<Component, Guid>
    {

        ValueTask<bool> CheckExistComponentAsync(Component component);
    }
}
