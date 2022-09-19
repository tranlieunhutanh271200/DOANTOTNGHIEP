using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCustomization.Persistence
{
    public class IdentityDbContext: DbContext
    {
        public IdentityDbContext(string connectionString): base(connectionString)
        {

        }
    }
}
