using Microsoft.EntityFrameworkCore;
using Service.Core.Models.Customization;
using Service.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCustomization.Persistence
{
    public class CustomizationDbContext: DbContext, IDbContext
    {
        public CustomizationDbContext(DbContextOptions<CustomizationDbContext> options): base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<DefaultRoute> DefaultRoutes { get; set; }
        public DbSet<Addon> Addons { get; set; }

    }
}
