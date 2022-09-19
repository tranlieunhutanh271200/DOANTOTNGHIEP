using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Core.Models.Customization;
using Service.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCustomization.Persistence.Repositories
{
    public class MenuRepository : AsyncRepository<Menu, Guid>, IMenuRepository
    {
        public MenuRepository(CustomizationDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async Task<Menu> UpdateCustomMenu(Guid accountId, List<Addon> addons)
        {
            Menu menu = await GetEntity(accountId);
            throw new NotImplementedException();
        }
    }
}
