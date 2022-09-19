using Service.Core.Models.Customization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCustomization.Persistence.Repositories
{
    public interface IMenuRepository
    {
        Task<Menu> UpdateCustomMenu(Guid accountId,List<Addon> addons);
    }
}
