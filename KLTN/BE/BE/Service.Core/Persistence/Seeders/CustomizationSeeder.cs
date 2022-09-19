using Microsoft.EntityFrameworkCore;
using Service.Core.Models.Customization;
using System;

namespace Service.Core.Persistence.Seeders
{
    public class CustomizationSeeder : BaseSeeder
    {
        public override void Seed(DbContext dbContext, Guid domainId, Guid accountId)
        {
            Menu menu = new Menu()
            {
                AccountId = accountId,
                IsCollapsed = true,
            };
            dbContext.Add(menu);
            Addon ticket = new Addon()
            {
                ElementId = "addon-ticket",
                Path = "/menu/ticket",
                Menu = menu
            };
            Addon jira = new Addon()
            {
                ElementId = "addon-jira",
                Path = "/menu/jira",
                Menu = menu
            };
            Addon chat = new Addon
            {
                ElementId = "addon-chat",
                Path = "/menu/chat",
                Menu = menu
            };
            menu.Addons.Add(ticket);
            menu.Addons.Add(jira);
            menu.Addons.Add(chat);
            dbContext.SaveChanges();
        }
    }
}
