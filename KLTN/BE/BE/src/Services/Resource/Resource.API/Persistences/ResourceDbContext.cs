using Microsoft.EntityFrameworkCore;
using Service.Core.Models.Resources;

namespace Resource.API.Persistences
{
    public class ResourceDbContext : DbContext
    {
        public ResourceDbContext(DbContextOptions<ResourceDbContext> options) : base(options)
        {

        }
        public DbSet<File> Files { get; set; }
        public DbSet<DomainDirectory> DomainDirectories { get; set; }
    }
}
