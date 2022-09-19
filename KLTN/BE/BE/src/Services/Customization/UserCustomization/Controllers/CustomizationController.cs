using Microsoft.AspNetCore.Mvc;
using Service.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCustomization.Persistence;

namespace UserCustomization.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CustomizationController: ControllerBase
    {
        private CustomizationDbContext _db;
        private ISeeder _seeder;
        public CustomizationController(CustomizationDbContext db, ISeeder seeder)
        {
            _db = db;
            _seeder = seeder;
        }
        [HttpPost("seed/{accountId}")]
        public async Task<IActionResult> SeedAccountCustomization(Guid accountId)
        {
            _seeder.Seed(_db, Guid.Empty, accountId);
            return Ok();
        }
    }
}
