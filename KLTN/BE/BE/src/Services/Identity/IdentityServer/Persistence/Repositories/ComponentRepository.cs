using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Core.Models.Identities;
using Service.Core.Persistence;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.Repositories
{
    public class ComponentRepository : AsyncRepository<Component, Guid>, IComponentRepository
    {
        public ComponentRepository(DbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async ValueTask<bool> CheckExistComponentAsync(Component component)
        {
            var isExistComponent = await ExistAsync(x => x.ComponentName == component.ComponentName && x.ComponentEndpoint == component.ComponentEndpoint);
            if (isExistComponent)
            {
                return true;
            }
            return false;
        }
    }
}
