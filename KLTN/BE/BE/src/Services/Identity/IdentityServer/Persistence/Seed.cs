using IdentityServer.Persistence.Consts;
using Service.Core.Models.Identities;
using Service.Core.Utils;
using System.Linq;

namespace IdentityServer.Persistence
{
    public class Seed : ISeeder
    {
        public async void SeedData(IdentityDbContext dbContext)
        {
            Component hrcomponent = new Component
            {
                ComponentName = "Quản lý nguồn lực",
                ComponentEndpoint = "/manage-hr",
                ComponentLogo = "people-outline"
            };
            Component taskcomponent = new Component
            {
                ComponentName = "Quản lý công việc",
                ComponentEndpoint = "/manage-task",
                ComponentLogo = "clipboard-outline"
            };
            Component ticketcomponent = new Component
            {
                ComponentName = "Quản lý phiếu",
                ComponentEndpoint = "/manage-ticket",
                ComponentLogo = "ticket-outline"
            };
            Component onlinecomponent = new Component
            {
                ComponentName = "Quản lý học TT",
                ComponentEndpoint = "/manage-online",
                ComponentLogo = "rocket-outline"
            };
            dbContext.Add(hrcomponent);
            dbContext.Add(ticketcomponent);
            dbContext.Add(taskcomponent);
            dbContext.Add(onlinecomponent);
            Domain adminDomain = new Domain()
            {
                Abbreviation = DomainConst.ADMIN.ToLower(),
                IsActive = true,
                DomainStatus = Service.Core.Models.Identities.DomainStatus.APPROVED
            };
            Domain hcmuteDomain = new Domain()
            {
                SchoolName = "Trường đại học sư phạm kĩ thuật TP.HCM",
                SchoolEmail = "admin@hcmute.edu.vn",
                SchoolAddress = "So 1 vo van ngan",
                Abbreviation = DomainConst.HCMUTE.ToLower(),
                IsActive = true,
                DomainStatus = Service.Core.Models.Identities.DomainStatus.APPROVED
            };
            hcmuteDomain.Components.Add(new DomainComponent
            {
                Component = hrcomponent
            });
            hcmuteDomain.Components.Add(new DomainComponent
            {
                Component = ticketcomponent
            });
            hcmuteDomain.Components.Add(new DomainComponent
            {
                Component = taskcomponent
            });
            hcmuteDomain.Components.Add(new DomainComponent
            {
                Component = onlinecomponent
            });
            Domain hcmutDomain = new Domain()
            {
                SchoolName = "Trường đại học sư phạm TP.HCM",
                SchoolEmail = "admin@hcmut.edu.vn",
                SchoolAddress = "So 1 vo van ngan",
                Abbreviation = DomainConst.HCMUT.ToLower(),
                IsActive = true,
                DomainStatus = Service.Core.Models.Identities.DomainStatus.REVIEW
            };
            Domain hutechDomain = new Domain()
            {
                SchoolName = "Trường đại học Hutech TP.HCM",
                SchoolEmail = "admin@hutech.edu.vn",
                SchoolAddress = "So 1 vo van ngan",
                Abbreviation = DomainConst.HUTECH.ToLower(),
                IsActive = true,
                DomainStatus = Service.Core.Models.Identities.DomainStatus.NEW
            };
            Domain gtvtDomain = new Domain()
            {
                SchoolName = "Trường đại học giao thông vận tải TP.HCM",
                SchoolEmail = "admin@uth-hcmc.edu.vn",
                SchoolAddress = "So 1 vo van ngan",
                Abbreviation = DomainConst.UTHCMC.ToLower(),
                IsActive = true,
                DomainStatus = Service.Core.Models.Identities.DomainStatus.DECLINED
            };
            dbContext.Add(hcmutDomain);
            dbContext.Add(hutechDomain);
            dbContext.Add(gtvtDomain);
            if (!dbContext.Roles.Any())
            {
                RoleConst roles = new RoleConst();
                foreach (var roleField in typeof(RoleConst).GetFields())
                {
                    Role sysRole = new Role()
                    {
                        RoleName = roleField.GetValue(roles).ToString()
                    };
                    dbContext.Roles.Add(sysRole);
                }
                dbContext.SaveChanges();
            }
            if (!dbContext.Domains.Any(domain => domain.Abbreviation == DomainConst.ADMIN.ToLower()))
            {
                dbContext.Domains.Add(adminDomain);
                dbContext.SaveChanges();
            }
            if (!dbContext.Domains.Any(domain => domain.Abbreviation == DomainConst.HCMUTE))
            {
                dbContext.Domains.Add(hcmuteDomain);
                dbContext.SaveChanges();
            }
            if (!dbContext.Accounts.Any(acc => acc.Role.RoleName == RoleConst.DOMAIN_ADMIN))
            {
                Role role = dbContext.Roles.FirstOrDefault(r => r.RoleName == RoleConst.DOMAIN_ADMIN);
                CryptoUtil.MD5.Hash("admin@123", out var salt, out string hashed);
                Account account = new Account()
                {
                    Username = "admin",
                    HashPassword = hashed,
                    Salt = salt,
                    Email = "admin@admin.com",
                    Domain = adminDomain,
                    Role = role,
                };
                dbContext.Accounts.Add(account);
                dbContext.SaveChanges();
            }
            if (!dbContext.Accounts.Any(acc => acc.Role.RoleName == RoleConst.SCHOOL_STUDENT))
            {
                Role role = dbContext.Roles.FirstOrDefault(r => r.RoleName == RoleConst.SCHOOL_STUDENT);
                CryptoUtil.MD5.Hash("password@123", out var salt, out string hashed);
                Account account = new Account
                {
                    Username = "test",
                    PhotoImage = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D",
                    HashPassword = hashed,
                    Salt = salt,
                    Email = "test@test.com",
                    Domain = hcmuteDomain,
                    Role = role
                };
                dbContext.Add(account);
                Account account1 = new Account
                {
                    Username = "nhutanh",
                    PhotoImage = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D",
                    HashPassword = hashed,
                    Salt = salt,
                    Email = "test1@test.com",
                    Domain = hcmuteDomain,
                    Role = role
                };
                dbContext.Add(account1);
                Account account2 = new Account
                {
                    Username = "huythe",
                    PhotoImage = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D",
                    HashPassword = hashed,
                    Salt = salt,
                    Email = "test2@test.com",
                    Domain = hcmuteDomain,
                    Role = role
                };
                dbContext.Add(account);
                dbContext.SaveChanges();
            }
            if (!dbContext.Accounts.Any(acc => acc.Role.RoleName == RoleConst.SCHOOL_TEACHER))
            {
                Role role = dbContext.Roles.FirstOrDefault(r => r.RoleName == RoleConst.SCHOOL_TEACHER);
                CryptoUtil.MD5.Hash("password@123", out var salt, out string hashed);
                Account account = new Account
                {
                    Username = "minhchau",
                    PhotoImage = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D",
                    HashPassword = hashed,
                    Salt = salt,
                    Email = "minhchau@hcmute.com",
                    Domain = hcmuteDomain,
                    Role = role
                };
                dbContext.Add(account);
                Account account1 = new Account
                {
                    Username = "thivan",
                    PhotoImage = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D",
                    HashPassword = hashed,
                    Salt = salt,
                    Email = "thivan@hcmute.com",
                    Domain = hcmuteDomain,
                    Role = role
                };
                dbContext.Add(account);
                dbContext.SaveChanges();
            }
            if (dbContext.Domains.Any(x => x.Abbreviation == "hcmute"))
            {
                var domain = dbContext.Domains.FirstOrDefault(x => x.Abbreviation == "hcmute");
                Role schoolAdminRole = dbContext.Roles.FirstOrDefault(r => r.RoleName == RoleConst.SCHOOL_ADMIN);

                if (!dbContext.Accounts.Any(x => x.RoleId == schoolAdminRole.Id))
                {
                    CryptoUtil.MD5.Hash("password@123", out var salt, out string hashed);
                    Account schoolAdmin = new Account
                    {
                        Username = "hcmute-admin",
                        PhotoImage = "https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D",
                        HashPassword = hashed,
                        Salt = salt,
                        Email = "admin@hcmute.edu.vn",
                        Domain = domain,
                        Role = schoolAdminRole
                    };
                    dbContext.Add(schoolAdmin);
                    dbContext.SaveChanges();
                }

            }
        }
    }
}
